using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int slotID;//空格ID 等于 物品ID
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public string slotInfo;

    public GameObject itemInSlot;

    public void ItemOnClicked()
    {
        InventoryManager.UpdateItemInfo(slotInfo);
        transform.parent.parent.GetComponent<ItemUse>().ItemSelected(slotItem);
    }

    public void SetupSlot(Item item)
    {
        if(item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }

        slotItem = item;
        slotItem.attr = item.attr;
        slotItem.param = item.param;
        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;

    }
}
