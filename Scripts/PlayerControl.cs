using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    ////�����ٶ�
    //public float speed = 8f;
    ////����2d����
    //Rigidbody2D rbody;
    ////���嶯��
    //Animator anim;
    ////��ʼ��Ļ��
    //Vector2 lookDirection = new Vector2(0, -1);

    ////����һ�������˶���
    //GameObject robotObj;
    ////��󽡿�ֵ
    //private int maxHealth = 2;//��Ϊ2;
    ////��ǰ����ֵ
    //private int currentHealth;
    ////�����ű��ɻ�ȡ��󽡿�ֵ
    //public int MyMaxHealth { get { return maxHealth; } }
    ////�����ű��ɻ�ȡ��ǰ����ֵ
    //public int MyCurrentHealth { get { return currentHealth; } }

    ////�޵�ʱ��
    //private float wuditime = 2f;
    ////�޵м�ʱ��
    //private float wuditimer;
    ////�޵�״̬
    //private bool isWudi;

    ////�ӵ�����
    //[SerializeField]
    //private int curBulletCount = 1;

    //private int maxBulletCount = 6;

    //public float gametime = 0;

    //public int MyCurBulletCount { get { return curBulletCount; } }
    //public int MyMaxBulletCount { get { return maxBulletCount; } }
    ////�ӵ�Ԥ����
    //public GameObject bulletPrefab;

    ////����ʣ������
    //public static int enemyleft;
    ////public int curEnemyleft { get { return enemyleft; } }

    ////��Ϸ������ʾ
    //public GameObject GameOver;
    ////ָ��Ϊ���ǲ�����
    //public GameObject GameOverPlayer;
    ////���������ʾ
    //public GameObject MissionCompleted;
    ////�޷�ʵ���������ű���������ʾ�����ڴ˽ű�����ʱ����
    //public float showTime = 3;
    //private float showTimer;

    ////������ʾ���ʱ��
    //public float tiptime = 6;
    //private float tiptimer;

    ////������ɱ�ǣ���ʾ��־��һ����Ϸ��ֻ��ʾһ��
    //public static int showflag = 0;

    ////�����Ч
    //public AudioClip hitClip;
    //public AudioClip launchClip;

    ////������ʾ�ı�
    //public Text tips;
    //public GameObject tipsframe;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    //������ʽѡ��
    //    ctrlway();
    //    //�������״̬�ĳ�ʼ��
    //    showflag = 0;
    //    //�������������ʾ
    //    MissionCompleted.SetActive(false);
    //    //��ʾ��ʱ������Ϊ��ֵ
    //    showTimer = -1;
    //    tiptimer = -1;
    //    //��ʼ��Ϸ���ʼ����������
    //    SetEnemyNum();


    //    //��ȡ2d����
    //    rbody = GetComponent<Rigidbody2D>();
    //    //��ȡ�������
    //    anim = GetComponent<Animator>();


    //    //��ʼ������ֵ
    //    currentHealth = 1;
    //    //��ʼ���޵�ʱ��
    //    wuditimer = 0;
    //    //�������������ӵ�����
    //    UIManager.instance.UpdateHealthBar(currentHealth, maxHealth);
    //    UIManager.instance.UpdateBulletCount(curBulletCount, maxBulletCount);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (showflag != 1)
    //    {
    //        UpdateTime();
    //    }
    //    UpdateEnemyLeft();

    //    //���������ʾ ��ʱ��
    //    showTimer -= Time.deltaTime;
    //    //��ʾ����ʾ ��ʱ��
    //    tiptimer -= Time.deltaTime;

    //    //����ʱ���ȡ����ʾ�������
    //    if (showTimer < 0)
    //    {
    //        MissionCompleted.SetActive(false);
    //    }

    //    /*//����ʱ���ȡ����ʾ��ʾ�ı�
    //    if(tiptimer<0)
    //    {
    //        tipsframe.SetActive(false);
    //    }*/

    //    //ȡ����ʾ��ʾ�ı�
    //    if (showTimer + 5 < 0)
    //    {
    //        tipsframe.SetActive(false);
    //    }

    //    //��������Ϊ0�������ǵ�һ�δﵽ0��֮ǰû����������������
    //    if (enemyleft == 0 && showflag != 1)
    //    {
    //        //������ʱ����ֵ���Դ���ʾ��ʾ
    //        showTimer = showTime;
    //        //�Ѿ���������ˣ����һ�£�֮������ʾ
    //        showflag = 1;
    //        //��ʾ���������ʾ
    //        MissionCompleted.SetActive(true);
    //        //��ʾǰ����һ�ص���ʾ
    //        tip();
    //    }

    //    //�������ֵΪ0����ʾ��Ϸ��������������������
    //    if (currentHealth == 0)
    //    {
    //        GameOver.SetActive(true);
    //        tip();
    //        GameObject.Find("Ruby").GetComponent<PlayerControl>().enabled = false;
    //        //gameObject.SetActive(false);
    //        //Destroy(GameOverPlayer);
    //    }

    //    //���û���ӵ��ˣ��������ʾ
    //    if (curBulletCount == 0 && currentHealth != 0)
    //    {
    //        tip();
    //    }

    //    //�����Ϸ��ʱ���������ʾ
    //    if (gametime > 180)
    //    {
    //        tip();
    //    }

    //    float moveX = 0;
    //    float moveY = 0;

    //    //���û�н��ü���
    //    if (UIEntry.ctrlflag != 2)
    //    {
    //        //��ȡ�˶�ʸ��
    //        moveX = Input.GetAxisRaw("Horizontal");
    //        moveY = Input.GetAxisRaw("Vertical");
    //    }

    //    Vector2 moveVector = new Vector2(moveX, moveY);

    //    if (moveX != 0 || moveY != 0)
    //    {
    //        lookDirection = moveVector;
    //    }

    //    Vector2 position = transform.position;
    //    position.x += moveX * speed * Time.deltaTime;
    //    position.y += moveY * speed * Time.deltaTime;

    //    transform.position = new Vector2(position.x, position.y);
    //    //�ø����ƶ������������涶��
    //    rbody.MovePosition(position);

    //    //Ϊ��������ֵ
    //    //״̬�����л����˶�ʸ������
    //    anim.SetFloat("move X", lookDirection.x);
    //    anim.SetFloat("move Y", lookDirection.y);
    //    anim.SetFloat("runspeed", moveVector.magnitude);
    //    //��ֵ������״̬������һ��


    //    //��������޵�״̬���ͼ�ʱ
    //    if (isWudi)
    //    {
    //        wuditimer -= Time.deltaTime;
    //        //��ʱ����0���Ͳ������޵�״̬��
    //        if (wuditimer < 0)
    //        {
    //            isWudi = false;
    //        }
    //    }

    //    //������J�������ӵ�����0������û�н��ü��̣�
    //    if (Input.GetKeyDown(KeyCode.J) && curBulletCount > 0 && UIEntry.ctrlflag != 2)
    //    {
    //        ChangeBulletCount(-1);
    //        anim.SetTrigger("Launch");
    //        AudioManager.instance.AudioPlay(launchClip);
    //        GameObject bullet = Instantiate(bulletPrefab, rbody.position + Vector2.up * 0.5f, Quaternion.identity);
    //        BulletControl bc = bullet.GetComponent<BulletControl>();
    //        if (bc != null)
    //        {
    //            bc.Shoot(lookDirection, 300);
    //        }
    //    }
    //    //��������������ǹ(û�н������)
    //    if (Input.GetMouseButtonDown(1) && curBulletCount > 0 && UIEntry.ctrlflag != 3)
    //    {
    //        RaycastHit2D raycast = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    //        Vector2 hitPoint = new Vector2(raycast.point.x, raycast.point.y);
    //        Vector2 curposition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    //        Vector2 ShootDirection = hitPoint - curposition;
    //        ChangeBulletCount(-1);
    //        anim.SetTrigger("Launch");
    //        AudioManager.instance.AudioPlay(launchClip);
    //        GameObject bullet = Instantiate(bulletPrefab, rbody.position + Vector2.up * 0.5f, Quaternion.identity);
    //        BulletControl bc = bullet.GetComponent<BulletControl>();
    //        if (bc != null)
    //        {
    //            bc.Shoot(ShootDirection, 300);//lookDirection
    //        }
    //    }
    //    //��E��npc����
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        RaycastHit2D hit = Physics2D.Raycast(rbody.position, lookDirection, 2f, LayerMask.GetMask("NPC"));
    //        if (hit.collider != null)
    //        {
    //            Debug.Log("hit npc!");
    //            NPCManager npc = hit.collider.GetComponent<NPCManager>();
    //            if (npc != null)
    //            {
    //                npc.ShowDialog();
    //            }
    //        }
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //�ȵ��������Զ����ɽ�ʬ
    //    float robotX = Random.Range(-3, 5);
    //    float robotY = Random.Range(-3, 5);
    //    Vector2 position_robot = new Vector2(robotX, robotY);

    //    if (collision.gameObject.tag == "bomb")//�����������
    //    {
    //        print("other.tag=" + collision.gameObject.tag);//���һ��Ҫ�У���Ȼ������
    //        robotObj = Instantiate(Resources.Load("Prefabs/Robot"), position_robot, Quaternion.identity) as GameObject;//������Դ,����һ��Ԥ���壬����һ������
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    //�뿪��������ʬ��ʧ
    //    if (collision.gameObject.tag == "bomb")
    //    {
    //        Destroy(robotObj);
    //    }
    //}

    //public void changeHealth(int amount)
    //{
    //    //�������ܵ��˺���Ҳ�����Ǽ�Ѫ
    //    if (amount < 0)
    //    {
    //        //��������ˣ������޵�״̬����2���ڲ�������
    //        if (isWudi == true)
    //        {
    //            return;
    //        }
    //        isWudi = true;
    //        //�������˶���
    //        anim.SetTrigger("Hit");
    //        //����������Ч
    //        AudioManager.instance.AudioPlay(hitClip);
    //        //Ϊ�޵м�ʱ����ֵ
    //        wuditimer = wuditime;
    //    }
    //    //���Ľ���ֵ
    //    currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    //    //����Ѫ��
    //    UIManager.instance.UpdateHealthBar(currentHealth, maxHealth);
    //    //����
    //    Debug.Log(currentHealth + "/" + maxHealth);
    //}

    //public void ChangeBulletCount(int amount)
    //{
    //    //�ı��ӵ���
    //    curBulletCount = Mathf.Clamp(curBulletCount + amount, 0, maxBulletCount);
    //    //�ı�UI�ӵ���
    //    UIManager.instance.UpdateBulletCount(curBulletCount, maxBulletCount);
    //}

    //public void UpdateTime()
    //{
    //    //��Ϸʱ��
    //    gametime += Time.deltaTime;
    //    //Debug.Log((int)gametime);

    //    //�ı�UIʱ��
    //    UIManager.instance.UpdateTimeBar((int)gametime);
    //}

    //public void UpdateEnemyLeft()
    //{
    //    UIManager.instance.UpdateEnemyLeft(enemyleft);
    //}

    //void SetEnemyNum()
    //{
    //    int index = SceneManager.GetActiveScene().buildIndex;
    //    if (index == 1)
    //    {
    //        enemyleft = 2;
    //    }
    //    if (index == 2)
    //    {
    //        enemyleft = 3;
    //    }
    //}

    ////public void ctrlway()
    ////{
    ////    if (UIEntry.ctrlflag == 1)
    ////    {
    ////        GameObject.Find("Ruby").GetComponent<PlayerControl>().enabled = true;
    ////        GameObject.Find("Ruby").GetComponent<Follow>().enabled = true;
    ////    }
    ////    else if (UIEntry.ctrlflag == 2)
    ////    {
    ////        //���ܽ�������ű�,��Ϊ��if���������UIEntry.ctrlflag���ò���
    ////        //GameObject.Find("Ruby").GetComponent<PlayerControl>().enabled = false;
    ////        GameObject.Find("Ruby").GetComponent<Follow>().enabled = true;
    ////    }
    ////    else if (UIEntry.ctrlflag == 3)
    ////    {
    ////        GameObject.Find("Ruby").GetComponent<PlayerControl>().enabled = true;
    ////        GameObject.Find("Ruby").GetComponent<Follow>().enabled = false;
    ////    }
    ////}
    ////public void tip()
    ////{
    ////    //tiptimer = tiptime;

    ////    if (showflag == 1)
    ////    {
    ////        int index = SceneManager.GetActiveScene().buildIndex;
    ////        if (index == 1)
    ////        {
    ////            tipsframe.SetActive(true);
    ////            tips.text = "Tips:\n��ǰ���Ǳ���������һ�ذ�!";
    ////        }
    ////        else if (index == 2)
    ////        {
    ////            tipsframe.SetActive(true);
    ////            tips.text = "Tips:\n���ס����Ѿ�ͨ���ˣ������Ǻ���Ŷ!";
    ////        }
    ////    }
    ////    else if (currentHealth == 0)
    ////    {
    ////        tipsframe.SetActive(true);
    ////        int index = SceneManager.GetActiveScene().buildIndex;
    ////        if (index == 1)
    ////        {
    ////            tips.text = "Tips:\n�ó���ѵ�˰ɣ�����!";
    ////        }
    ////        else if (index == 2 && RobotControl.isFixed % 2 == 1)
    ////        {
    ////            tips.text = "Tips:\n�����˱���ŭ��������������Ŷ�������Ŷ�������������ι�����!";
    ////        }
    ////        else if (index == 2 && RobotControl.isFixed % 2 != 1)
    ////        {
    ////            tips.text = "Tips:\n��ɳ����ѵ�ɣ�����!";
    ////        }
    ////        else
    ////        {
    ////            return;
    ////        }
    ////    }
    ////    else if (curBulletCount == 0 && currentHealth != 0)
    ////    {
    ////        tipsframe.SetActive(true);
    ////        tips.text = "Tips:\nû���ӵ��ˣ���ȥʰȡ�ӵ���!";
    ////    }
    ////    else if (gametime > 180)
    ////    {
    ////        tipsframe.SetActive(true);
    ////        tips.text = "Tips:\n��Ϸ��ʱ��Ŷ";
    ////    }
    ////}
}