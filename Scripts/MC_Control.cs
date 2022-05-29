using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MC_Control : MonoBehaviour
{
    //GameObject
    public GameObject mouse_pointer;                                //鼠标的准心
    public GameObject bulletPrefab;                                 //子弹预制体
    public GameObject PlayerSprite;
    public GameObject PlayerBag;
    public GameObject GunEquipment;
    public GameObject TipPanel;
    public GameObject oceanMask;
    public DataSO dataStorage;


    //要改
    //public float HP = 3.0f;

    //不可见的数值
    private float walk_speed = 5.0f;                                //走路移动速度
    private float run_speed = 10.0f;                                //按左shift跑步速度
    private float stealth_speed = 2.0f;                             //按C进行潜行
    private float turnSmoothTime = 0.13f;                           //设定角色转向平滑时间
    float turnSmoothVelocity;                                       //平滑函数需要这么一个平滑加速度, 不需要赋值, 但是需要把这个变量当参数传入
    private Animator anim;
    private float t_r, t_theta = 0f;
    private float t_x, t_y = 0f;
    private float shootSpeed = 2.0f;

    //状态布尔
    //private bool is_acting = false;
    //private bool BagisOpen = false;
    private bool isUndamageable = false;
    private float Undamageabletimer = 0.0f;
    private bool GunUsing = true;
    private bool a = false;
    private Vector3 localscale;

    //其他
    Vector3 screenPosition;//将物体从世界坐标转换为屏幕坐标
    Vector3 mousePositionOnScreen;//获取到点击屏幕的屏幕坐标
    Vector3 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标

    void Start()
    {
        MouseFollow();
        anim = PlayerSprite.GetComponent<Animator>();
        Cursor.visible = false;
        oceanMask.SetActive(SceneManager.GetActiveScene().buildIndex == 8);
        localscale = transform.localScale;
    }

    void FixedUpdate()
    {
        Lookat();
    }

    // Update is called once per frame
    void Update()
    {
        //状态调整
        UndamageAblilityLost();
        MouseFollow();
        changeScale();

        if (!dataStorage.isTalking)
        {
            //移动
            if (!Input.GetKey(KeyCode.C))
                Move(Input.GetKey(KeyCode.LeftShift) ? run_speed : walk_speed);
            else
                Move(stealth_speed);

            if (GunEquipment)
            {
                CheckGunLayDown();
                if (GunUsing && !PlayerBag.activeSelf)
                    Shooting();
            }
            OpenBag();
            OpenTips();
        }
        else
        {
            Move(0f);
        }
    }

    void changeScale()
    {
        if (GetComponent<Rigidbody2D>().velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-localscale.x, localscale.y, localscale.z);
        }
        else if (GetComponent<Rigidbody2D>().velocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(localscale.x, localscale.y, localscale.z);
        }
    }

    void Move(float speed)
    {
        Vector2 move_attr = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
        anim.SetFloat("speed", (Mathf.Abs(move_attr.x) > 0 || Mathf.Abs(move_attr.y) > 0) ? 2.0f : 0.0f);
        anim.SetBool("Fire", Input.GetKey(KeyCode.LeftShift));
        GetComponent<Rigidbody2D>().velocity = move_attr;
        float Horizontal = Input.GetAxisRaw("Horizontal") * 2.0f;
        float Vertical = Input.GetAxisRaw("Vertical") * 2.0f;
        PlayerSprite.transform.position = transform.position;
        anim.SetFloat("horizontal", Horizontal);
        anim.SetFloat("vertical", Vertical);

        if (GunEquipment)
        {
            GunEquipment.transform.parent.transform.position = transform.position + new Vector3(0, -0.1f, 0);
        }
    }

    void Lookat()
    {
        Vector2 ShootDirection = new Vector2(mousePositionInWorld.x, mousePositionInWorld.y) - new Vector2(GunEquipment.transform.parent.transform.position.x, GunEquipment.transform.parent.transform.position.y);
        float fireangle = Vector2.Angle(ShootDirection, Vector3.up);
        //transform.eulerAngles = new Vector3(0, 0, mousePositionInWorld.x > transform.position.x ? -fireangle : fireangle);
        GunEquipment.transform.parent.transform.eulerAngles = Vector3.forward * Mathf.SmoothDampAngle(GunEquipment.transform.parent.transform.eulerAngles.z,
            mousePositionInWorld.x > GunEquipment.transform.parent.position.x ? -fireangle+90 : fireangle - 90, ref turnSmoothVelocity, turnSmoothTime);
        GunEquipment.GetComponent<SpriteRenderer>().flipX = mousePositionInWorld.x > GunEquipment.transform.parent.position.x ? false : true;
        if (GunEquipment.GetComponent<SpriteRenderer>().flipX)
        {
            if (a)
            {
                GunEquipment.transform.position = 2 * GunEquipment.transform.parent.position - GunEquipment.transform.position;
                a = false;
            }
        }
        else
        {
            if (!a)
            {
                GunEquipment.transform.position = 2 * GunEquipment.transform.parent.position - GunEquipment.transform.position;
                a = true;
            }
        }
    }

    void MouseFollow()
    {
        //获取鼠标在相机中（世界中）的位置，转换为屏幕坐标；
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //获取鼠标在场景中坐标
        mousePositionOnScreen = Input.mousePosition;
        //让场景中的Z=鼠标坐标的Z
        mousePositionOnScreen.z = screenPosition.z;
        //将相机中的坐标转化为世界坐标
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        //跟随鼠标移动
        mouse_pointer.transform.position = new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, transform.position.z);
    }

    void Shooting()
    {
        //if (Input.GetMouseButtonDown(1) && curBulletCount > 0 && UIEntry.ctrlflag != 3)
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit2D raycast = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //Vector2 hitPoint = new Vector2(raycast.point.x, raycast.point.y);
            //Vector2 curposition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            //Vector2 ShootDirection = hitPoint - curposition;

            // anim.SetBool()
            StartCoroutine(OnFire());

            Vector2 ShootDirection = new Vector2(mousePositionInWorld.x, mousePositionInWorld.y) - new Vector2(transform.position.x, transform.position.y);
            //ChangeBulletCount(-1);
            //anim.SetTrigger("Launch");
            //AudioManager.instance.AudioPlay(launchClip);
            //GameObject bullet = Instantiate(bulletPrefab, rbody.position + Vector2.up * 0.5f, Quaternion.identity);
            //GameObject bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x + 1.0f, transform.position.y + 1.0f), Quaternion.identity);


            changeXYToPolarCoordinate(ShootDirection.x, ShootDirection.y, ref t_r, ref t_theta);
            changePolarCoordinateToXY(1.0f, t_theta, ref t_x, ref t_y);

            GameObject bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x + t_x * 0.5f,
                transform.position.y + t_y * 0.5f), Quaternion.identity);

            ShootDirection.Normalize();

            BulletControl bc = bullet.GetComponent<BulletControl>();
            if (bc != null)
            {
                bc.Shoot(ShootDirection * shootSpeed, 300);//lookDirection
            }
        }
    }

    void OpenBag()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            //BagisOpen = !BagisOpen;
            if (!PlayerBag.activeSelf)
            {
                InventoryManager.UpdateItemInfo("");
            }
            PlayerBag.SetActive(!PlayerBag.activeSelf);
        }
    }

    void DeathCheck()
    {
        if (dataStorage.currentHealth <= 0.0f)
        {
            Debug.Log("Cai");
            SceneManager.LoadScene(4);
        }
    }

    public void ChangeHP(float value, bool isUndamageAblility)
    {
        //HP += value;
        //DataControl.ChangeHP(value);
        dataStorage.currentHealth = Mathf.Min(dataStorage.maxHealth, Mathf.Max(0f, dataStorage.currentHealth + value));
        if (isUndamageAblility)
        {
            isUndamageable = true;
            Undamageabletimer = 0.2f;
        }
        DeathCheck();
    }

    void UndamageAblilityLost()
    {
        //如果处于无敌状态，就计时
        if (isUndamageable)
        {
            Undamageabletimer -= Time.deltaTime;
            //计时器归0，就不处于无敌状态了
            if (Undamageabletimer < 0)
            {
                isUndamageable = false;
            }
        }
    }

    IEnumerator OnFire()
    {
        GunEquipment.GetComponent<Animator>().SetTrigger("onFire");
        yield return new WaitForSeconds(0.01f);
    }

    void CheckGunLayDown()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GunUsing = !GunUsing;
            GunEquipment.GetComponent<Animator>().SetBool("UsingGun", GunUsing);
        }
    }

    void changeXYToPolarCoordinate(float x, float y, ref float r, ref float angle)
    {
        if (x == 0f)
        {
            r = Mathf.Abs(y);//x轴为0，r等于y的绝对值  
            if (y < 0)//y小于0是270°  
            {
                angle = 270f;
            }
            else if (y > 0)//y大于0是90°  
            {
                angle = 90f;
            }
            else//原点  
            {
                angle = 0f;
            }
        }
        else
        {
            r = Mathf.Sqrt(x * x + y * y);  //与原点的距离
            angle = Mathf.Acos(x / r);
            if (y < 0)
            {
                angle *= -1.0f;   //反余弦函数  
            }
        }
    }
    //把极坐标转换成直角坐标  
    void changePolarCoordinateToXY(float r, float angle, ref float x, ref float y)
    {
        x = r * Mathf.Cos(angle);
        y = r * Mathf.Sin(angle);
    }

    void OpenTips()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TipPanel.SetActive(!TipPanel.activeSelf);
        }
    }
}

