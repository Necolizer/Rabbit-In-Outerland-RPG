using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RabbitItem : MonoBehaviour
{
    public AIPath aiPath;
    private bool following = false;
    private Rigidbody2D rig;
    private Vector3 localscale;
    void Start()
    {
        localscale = transform.localScale;
        rig = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // SetFollow();
        Follow();
        changeScale();
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            SetFollow();
        }
    }
    void Follow()
    {
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
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(following == false)
            {
                following = true;
            }else
            {
                following = false;
            }
        }
    }
    void changeScale()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-localscale.x, localscale.y, localscale.z);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(localscale.x, localscale.y, localscale.z);
        }
    }
}
