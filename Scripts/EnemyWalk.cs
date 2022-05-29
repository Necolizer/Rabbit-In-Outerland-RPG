using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [Header("敌人的基础属性/生命值/攻击力/防御力")]
    public float HP;
    public float Atk;
    public float Def;
    private float currentHP;
    private bool isUndamageable = false;
    private float Undamageabletimer = 0.0f;

    public DataSO dataStorage;
    [Header("敌人移速")]

    public float speed;
    [Header("敌人在到达点位后的等待时间")]
    public float waitTime;
    [Header("玩家")]
    public GameObject Player;
    [Header("敌人移动的固定点位")]
    public Vector2[] moveSpots;
    [Header("敌人的感应距离,0位置为最小距离,1位置为最大距离,至少包含两个变量")]
    public List<float> Plist;

    public GameObject turnInto;
    //public bool loadFromStart = true;


    private float Pdistance;
    private int i = 0;
    private float attackTime;
    private bool movingRight = true;
    private float wait;
    private bool startMoveTo;
    private SpriteRenderer spr;
    private Animator anim;
    private bool attk;
    private float attkTime;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = HP;
        wait = waitTime;
        attk = false;
        anim = GetComponent<Animator>();
        attackTime = GetAnimatorLength(anim, "enemy attack");
        attkTime = attackTime;
        Pdistance = Plist[1];
    }

    float EulerDistance(Vector2 size)
    {
        return Mathf.Sqrt(Mathf.Pow(size.x, 2) + Mathf.Pow(size.y, 2));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < Pdistance)
        {
            startMoveTo = true;
        }
        else
        {
            startMoveTo = false;
        }

        if (attk == true)
        {
            anim.SetBool("Fire", true);
            if(attkTime < 0.1f)
            {
                if(attk == true)
                    Player.GetComponent<MC_Control>().ChangeHP(-Atk, true);
                attkTime = attackTime;
            }
            attkTime -= Time.deltaTime;
        }
        else if(startMoveTo  == true)
        {
            MoveTo();
        }else
        {
            MoveToCheckpoint();
        }
    }

    void Update()
    {
        StealthCheck();
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

    void MoveTo()
    {
        // Vector3 of3 = GetComponent<BoxCollider2D>().offset;
        // Vector3 pof3 = Player.GetComponent<CapsuleCollider2D>().offset;
        //if (Vector2.Distance(transform.position, Player.transform.position) < Pdistance)
        //{
        //    attk = true;
        //}else
        //{
        transform.position = 
        Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        float directionx = Player.transform.position.x - transform.position.x;
        if(directionx > 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //}
        
    }

    void MoveToCheckpoint()
    {
        transform.position = 
            Vector2.MoveTowards(transform.position, moveSpots[i], speed * Time.deltaTime);
        float directionx = moveSpots[i].x - transform.position.x;
        if(directionx > 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Vector2.Distance(transform.position, moveSpots[i]) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                    
                }

                if (i == 0)
                {

                    i = 1;
                }
                else
                {

                    i = 0;
                }

                waitTime = wait;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(
            other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
            // && GetType().ToString() == "UnityEngine.CircleCollider2D"
            )
        {
            //startMoveTo = true;
            attk = true;
            attkTime = attackTime;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (
            other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
            // && GetType().ToString() == "UnityEngine.CircleCollider2D"
            )
        {
            //startMoveTo = false;
            anim.SetBool("Fire", false);
            attk = false;
        }
    }

    public float GetAnimatorLength(Animator animator ,string name)
    {
    	//动画片段时间长度
        float length = 0;

        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name.Equals(name))
            {
                length = clip.length;
                break;
            }
        }
        return length;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (
            other.gameObject.CompareTag("bullet")
            )
        {
            ChangeHP(-dataStorage.currentDamagePoints + Def);
            SetUndamageable(0.2f);
        }
    }

    private void ChangeHP(float value)
    {
        currentHP += value;
        if (currentHP <= 0)
        {
            if (turnInto)
            {
                GameObject enemyTurnInto = Instantiate(turnInto, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
            dataStorage.killNum += 1;
            Destroy(gameObject);
        }
    }

    private void SetUndamageable(float time)
    {
        isUndamageable = true;
        Undamageabletimer = time;
    }

    private void StealthCheck()
    {
        if (Input.GetKey(KeyCode.C))
        {
            if(!startMoveTo)
            {
                Pdistance = Plist[0];
            }
        }else
        {
            Pdistance = Plist[1];
        }
    }
}
