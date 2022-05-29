using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataControl : MonoBehaviour
{
    //static DataControl instance;
    ////HP
    //private float maxHealth = 50f;                                     //最大健康值
    //private float currentHealth;                                      //当前健康值 
    //public static float MyMaxHealth { get { return instance.maxHealth; } }            //其他脚本可获取最大健康值
    //public static float MyCurrentHealth { get { return instance.currentHealth; } }    //其他脚本可获取当前健康值

    //private bool isActing = false;
    //public static bool MyIsActing { get { return instance.isActing; } }

    //private float currentDamagePoints = 1.0f;
    //public static float DamagePoints { get { return instance.currentDamagePoints; } set{
    //    instance.currentDamagePoints = value;
    //} }

    //private bool mapHold = false;
    //public static bool MapHold
    //{
    //    get { return instance.mapHold; }
    //    set
    //    {
    //        instance.mapHold = value;
    //    }
    //}

    ////Money
    ////private int Money = 0;
    ////public int MyMoney { get { return Money; } }

    ////Bullet
    ////private int curBulletCount;
    ////private int maxBulletCount = 6;
    ////public int MyCurBulletCount { get { return curBulletCount; } }
    ////public int MyMaxBulletCount { get { return maxBulletCount; } }

    ////Bag

    //void Start()
    //{
    //    instance.currentHealth = instance.maxHealth;
    //}

    //void Awake()
    //{
    //    if (instance != null)
    //        Destroy(this);
    //    instance = this;
    //}

    //public static void ChangeHP(float value)
    //{
    //    instance.currentHealth = Mathf.Min(instance.maxHealth, Mathf.Max(0f, instance.currentHealth + value));
    //    //Debug.Log(instance.currentHealth);
    //}

    //public static void setActing(bool state)
    //{
    //    instance.isActing = state;
    //}
}
