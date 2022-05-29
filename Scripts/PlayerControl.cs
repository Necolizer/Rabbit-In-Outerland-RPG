using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    ////主角速度
    //public float speed = 8f;
    ////定义2d刚体
    //Rigidbody2D rbody;
    ////定义动画
    //Animator anim;
    ////初始屏幕看
    //Vector2 lookDirection = new Vector2(0, -1);

    ////定义一个机器人对象
    //GameObject robotObj;
    ////最大健康值
    //private int maxHealth = 2;//改为2;
    ////当前健康值
    //private int currentHealth;
    ////其他脚本可获取最大健康值
    //public int MyMaxHealth { get { return maxHealth; } }
    ////其他脚本可获取当前健康值
    //public int MyCurrentHealth { get { return currentHealth; } }

    ////无敌时间
    //private float wuditime = 2f;
    ////无敌计时器
    //private float wuditimer;
    ////无敌状态
    //private bool isWudi;

    ////子弹数量
    //[SerializeField]
    //private int curBulletCount = 1;

    //private int maxBulletCount = 6;

    //public float gametime = 0;

    //public int MyCurBulletCount { get { return curBulletCount; } }
    //public int MyMaxBulletCount { get { return maxBulletCount; } }
    ////子弹预制体
    //public GameObject bulletPrefab;

    ////敌人剩余数量
    //public static int enemyleft;
    ////public int curEnemyleft { get { return enemyleft; } }

    ////游戏结束提示
    //public GameObject GameOver;
    ////指定为主角并销毁
    //public GameObject GameOverPlayer;
    ////任务完成提示
    //public GameObject MissionCompleted;
    ////无法实现在其他脚本中销毁提示，故在此脚本中限时销毁
    //public float showTime = 3;
    //private float showTimer;

    ////智能提示框计时器
    //public float tiptime = 6;
    //private float tiptimer;

    ////任务完成标记，显示标志，一场游戏中只显示一次
    //public static int showflag = 0;

    ////玩家音效
    //public AudioClip hitClip;
    //public AudioClip launchClip;

    ////智能提示文本
    //public Text tips;
    //public GameObject tipsframe;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    //操作方式选择
    //    ctrlway();
    //    //任务完成状态的初始化
    //    showflag = 0;
    //    //隐藏任务完成提示
    //    MissionCompleted.SetActive(false);
    //    //提示计时器设置为负值
    //    showTimer = -1;
    //    tiptimer = -1;
    //    //开始游戏后初始化敌人数量
    //    SetEnemyNum();


    //    //获取2d刚体
    //    rbody = GetComponent<Rigidbody2D>();
    //    //获取动画组件
    //    anim = GetComponent<Animator>();


    //    //初始化生命值
    //    currentHealth = 1;
    //    //初始化无敌时间
    //    wuditimer = 0;
    //    //更新生命条与子弹数量
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

    //    //任务完成显示 计时器
    //    showTimer -= Time.deltaTime;
    //    //提示框显示 计时器
    //    tiptimer -= Time.deltaTime;

    //    //超过时间就取消显示任务完成
    //    if (showTimer < 0)
    //    {
    //        MissionCompleted.SetActive(false);
    //    }

    //    /*//超过时间就取消显示提示文本
    //    if(tiptimer<0)
    //    {
    //        tipsframe.SetActive(false);
    //    }*/

    //    //取消显示提示文本
    //    if (showTimer + 5 < 0)
    //    {
    //        tipsframe.SetActive(false);
    //    }

    //    //敌人数量为0，并且是第一次达到0，之前没有完成任务，任务完成
    //    if (enemyleft == 0 && showflag != 1)
    //    {
    //        //给倒计时器赋值，以此显示提示
    //        showTimer = showTime;
    //        //已经完成任务了，标记一下，之后不再显示
    //        showflag = 1;
    //        //显示任务完成提示
    //        MissionCompleted.SetActive(true);
    //        //显示前往下一关的提示
    //        tip();
    //    }

    //    //如果生命值为0，显示游戏结束字样，并销毁主角
    //    if (currentHealth == 0)
    //    {
    //        GameOver.SetActive(true);
    //        tip();
    //        GameObject.Find("Ruby").GetComponent<PlayerControl>().enabled = false;
    //        //gameObject.SetActive(false);
    //        //Destroy(GameOverPlayer);
    //    }

    //    //如果没有子弹了，则进行提示
    //    if (curBulletCount == 0 && currentHealth != 0)
    //    {
    //        tip();
    //    }

    //    //如果游戏超时，则进行提示
    //    if (gametime > 180)
    //    {
    //        tip();
    //    }

    //    float moveX = 0;
    //    float moveY = 0;

    //    //如果没有禁用键盘
    //    if (UIEntry.ctrlflag != 2)
    //    {
    //        //获取运动矢量
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
    //    //用刚体移动可以消除画面抖动
    //    rbody.MovePosition(position);

    //    //为动画集赋值
    //    //状态集的切换由运动矢量决定
    //    anim.SetFloat("move X", lookDirection.x);
    //    anim.SetFloat("move Y", lookDirection.y);
    //    anim.SetFloat("runspeed", moveVector.magnitude);
    //    //赋值必须与状态集命名一样


    //    //如果处于无敌状态，就计时
    //    if (isWudi)
    //    {
    //        wuditimer -= Time.deltaTime;
    //        //计时器归0，就不处于无敌状态了
    //        if (wuditimer < 0)
    //        {
    //            isWudi = false;
    //        }
    //    }

    //    //当按下J，并且子弹大于0，开火（没有禁用键盘）
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
    //    //按下鼠标左键，开枪(没有禁用鼠标)
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
    //    //按E与npc交互
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
    //    //踩到雷区，自动生成僵尸
    //    float robotX = Random.Range(-3, 5);
    //    float robotY = Random.Range(-3, 5);
    //    Vector2 position_robot = new Vector2(robotX, robotY);

    //    if (collision.gameObject.tag == "bomb")//如果碰到雷区
    //    {
    //        print("other.tag=" + collision.gameObject.tag);//这句一定要有，不然出不来
    //        robotObj = Instantiate(Resources.Load("Prefabs/Robot"), position_robot, Quaternion.identity) as GameObject;//加载资源,生成一个预制体，做成一个对象
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    //离开雷区，僵尸消失
    //    if (collision.gameObject.tag == "bomb")
    //    {
    //        Destroy(robotObj);
    //    }
    //}

    //public void changeHealth(int amount)
    //{
    //    //可能是受到伤害，也可能是加血
    //    if (amount < 0)
    //    {
    //        //如果是受伤，设置无敌状态，则2秒内不能受伤
    //        if (isWudi == true)
    //        {
    //            return;
    //        }
    //        isWudi = true;
    //        //播放受伤动画
    //        anim.SetTrigger("Hit");
    //        //播放受伤音效
    //        AudioManager.instance.AudioPlay(hitClip);
    //        //为无敌计时器赋值
    //        wuditimer = wuditime;
    //    }
    //    //更改健康值
    //    currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    //    //更新血条
    //    UIManager.instance.UpdateHealthBar(currentHealth, maxHealth);
    //    //调试
    //    Debug.Log(currentHealth + "/" + maxHealth);
    //}

    //public void ChangeBulletCount(int amount)
    //{
    //    //改变子弹数
    //    curBulletCount = Mathf.Clamp(curBulletCount + amount, 0, maxBulletCount);
    //    //改变UI子弹数
    //    UIManager.instance.UpdateBulletCount(curBulletCount, maxBulletCount);
    //}

    //public void UpdateTime()
    //{
    //    //游戏时间
    //    gametime += Time.deltaTime;
    //    //Debug.Log((int)gametime);

    //    //改变UI时间
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
    ////        //不能禁用这个脚本,改为在if语句中利用UIEntry.ctrlflag禁用操作
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
    ////            tips.text = "Tips:\n快前往城堡，进行下一关吧!";
    ////        }
    ////        else if (index == 2)
    ////        {
    ////            tipsframe.SetActive(true);
    ////            tips.text = "Tips:\n亲亲、你已经通关了，请五星好评哦!";
    ////        }
    ////    }
    ////    else if (currentHealth == 0)
    ////    {
    ////        tipsframe.SetActive(true);
    ////        int index = SceneManager.GetActiveScene().buildIndex;
    ////        if (index == 1)
    ////        {
    ////            tips.text = "Tips:\n该长教训了吧，哈哈!";
    ////        }
    ////        else if (index == 2 && RobotControl.isFixed % 2 == 1)
    ////        {
    ////            tips.text = "Tips:\n机器人被激怒，会主动攻击人哦。尝试着对它连续完成两次攻击吧!";
    ////        }
    ////        else if (index == 2 && RobotControl.isFixed % 2 != 1)
    ////        {
    ////            tips.text = "Tips:\n你可长点教训吧，哈哈!";
    ////        }
    ////        else
    ////        {
    ////            return;
    ////        }
    ////    }
    ////    else if (curBulletCount == 0 && currentHealth != 0)
    ////    {
    ////        tipsframe.SetActive(true);
    ////        tips.text = "Tips:\n没有子弹了，快去拾取子弹吧!";
    ////    }
    ////    else if (gametime > 180)
    ////    {
    ////        tipsframe.SetActive(true);
    ////        tips.text = "Tips:\n游戏超时了哦";
    ////    }
    ////}
}