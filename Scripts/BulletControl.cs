using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Pathfinding;

public class BulletControl : MonoBehaviour
{
    Rigidbody2D rbody;
    // [Header("子弹攻击力")]
    // public float DamagePoints;
    //子弹命中声
    //public AudioClip hitClip;

    // Start is called before the first frame update
    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        //2秒后不管打没打中，子弹销毁子弹
        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //子弹发射，射击
    public void Shoot(Vector2 moveDirection, float moveForce)
    {
        rbody.AddForce(moveDirection * moveForce);
    }

    //子弹命中
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ////调用机器人控制脚本的修复函数，修改机器人的状态
        //RobotControl ec = collision.gameObject.GetComponent<RobotControl>();
        //if (ec != null)
        //{
        //    ec.Fixed();//杀敌
        //    if (RobotControl.isFixed % 2 == 0)
        //    {
        //        collision.gameObject.GetComponent<AIPath>().enabled = false;
        //        PlayerControl.enemyleft--;//更改玩家控制中的击杀数，以此判断任务是否完成，格式：脚本名.静态变量--;
        //        Debug.Log("当前敌人数：" + PlayerControl.enemyleft);
        //    }
        //    if (RobotControl.isFixed % 2 != 0)
        //    {
        //        //打开命中对象的AI组件
        //        collision.gameObject.GetComponent<AIPath>().enabled = true;
        //        //collision.gameObject.GetComponent<RobotControl>().enabled = false;
        //        //RobotControl.AIon();
        //        //ScriptSelect.changestatus();
        //    }
        //    Debug.Log("命中敌人了");
        //}
        //播放命中声
        //AudioManager.instance.AudioPlay(hitClip);
        //立即销毁子弹
        Destroy(this.gameObject);
    }
}
