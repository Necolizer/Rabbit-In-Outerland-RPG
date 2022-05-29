using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class rabbitRun : MonoBehaviour
{
    [Header("自有属性,不建议修改")]
    public AIPath aiPath;
    [Header("玩家位置/目标点位置")]
    public Transform PlayerTransform;
    public List<Transform> myTarget;
    [Header("物品属性/物品所在背包")]
    public Item rabbit;
    public Inventory inv;
    [Header("玩家感应距离")]
    public float Pdistance = 5f;
    [Header("可被拾取的距离")]
    public float pickDistance = 1f;
    private float distance;
    private AIDestinationSetter destination;
    private Vector3 localscale;
    private int id = 0;
    private bool following = false;
    private bool preset;
    private Rigidbody2D rig;
    void Start()
    {
        localscale = transform.localScale;
        rig = this.GetComponent<Rigidbody2D>();
        destination = GetComponent<AIDestinationSetter>();
        destination.target = myTarget[id];
    }

    void Update()
    {
        StealthCheck();
        if(true)
        {
            SetFollow();
        }
        Follow();
        changeScale();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            preset = true;
            // SetFollow();
        }
    }
    private void SetTarget()
    {
        id = id + 1;
        if(id > myTarget.Count - 1)
        {
            id = 0;
        }
        destination.target = myTarget[id];
        preset = false;
    }
    void Follow()
    {
        if(aiPath.reachedEndOfPath)//|| Vector2.Distance(transform.position, myTarget[id].position) < 0.01f
        {
            following = false;
        }
        if(following)
        {
            rig.constraints = RigidbodyConstraints2D.FreezeRotation;
        }else
        {
            rig.constraints = RigidbodyConstraints2D.FreezeAll;;
        }
    }
    void SetFollow()
    {
        if(Vector2.Distance(transform.position, PlayerTransform.position) < distance)
        {
            following = true;
            SetTarget();
        }
    }
    void changeScale()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(localscale.x, localscale.y, localscale.z);
        }else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-localscale.x, localscale.y, localscale.z);
        }
    }
    private void StealthCheck()
    {
        if(Input.GetKey(KeyCode.F) && Vector2.Distance(transform.position, PlayerTransform.position) < pickDistance)
        {
            if(inv.itemList.Contains(rabbit)== false)
            {
            //inv.itemList.Add(rewards);
                for (int i = 0; i < inv.itemList.Count; i++)
                {
                    if (inv.itemList[i] == null)
                    {
                        inv.itemList[i] = rabbit;
                        rabbit.itemHeld++;
                        break;
                    }
                }
            }InventoryManager.RefreshItem();
            // rabbit.itemHeld++;
            Destroy(gameObject);
        }
        if (Input.GetKey(KeyCode.C))
        {
            if(!following)
            {
                distance = 0;
            }
        }else
        {
            distance = Pdistance;
        }
    }
}