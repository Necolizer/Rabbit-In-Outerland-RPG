using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{
    [Header("物品对应的Item")]
    public Item thisItem;
    [Header("物品所在的背包")]
    public Inventory playerInventory;

    private bool ReadyToBeCollected;
    // Start is called before the first frame update
    void Start()
    {
        ReadyToBeCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ReadyToBeCollected && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Grab an Item");
            AddNewItem();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (
            other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
        )
        {
            ReadyToBeCollected = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (
            other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
        )
        {
            ReadyToBeCollected = false;
        }
    }

    public void AddNewItem()
    {
        if(!playerInventory.itemList.Contains(thisItem))
        {
            //playerInventory.itemList.Add(thisItem);
            for(int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if(playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    thisItem.itemHeld += 1;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        InventoryManager.RefreshItem();
    }
}
