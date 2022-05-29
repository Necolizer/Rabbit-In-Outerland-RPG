using System.Runtime.Serialization;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    public Inventory inv;
    public Item selectedItem = null;
    public DataSO dataStorage;

    void OnDisable()
    {
        selectedItem = null;
    }

    public void ItemSelected(Item item)
    {
        selectedItem = item;
    }

    public void ItemDelete()
    {
        if (selectedItem)
        {
            if (selectedItem.deleteable)
            {
                selectedItem.itemHeld = 0;
                for (int i = 0; i < inv.itemList.Count; i++)
                {
                    if (inv.itemList[i] == selectedItem)
                    {
                        inv.itemList[i] = null;
                        selectedItem = null;
                        break;
                    }
                }
                InventoryManager.RefreshItem();
            }else
            {
                InventoryManager.UpdateItemInfo("重要道具 不可删除");
            }
        }
    }

    public void ItemApply()
    {
        if (selectedItem)
        {
            // UnityEngine.Debug.Log("attr:"+selectedItem.attr);
            
            if (selectedItem.attr == Attribute.Gun)
            {
                dataStorage.currentDamagePoints = selectedItem.param;
                InventoryManager.UpdateItemInfo("武器已装备");
                UnityEngine.Debug.Log("damage:"+ dataStorage.currentDamagePoints);
            }
            else if (selectedItem.attr == Attribute.Healer)
            {
                //DataControl.ChangeHP(selectedItem.param);
                dataStorage.currentHealth = Mathf.Min(dataStorage.maxHealth, Mathf.Max(0f, dataStorage.currentHealth + selectedItem.param));
                // UnityEngine.Debug.Log("healer:"+selectedItem.attr.ToString());
                selectedItem.itemHeld -= 1;
                InventoryManager.UpdateItemInfo("已回复部分HP");
            }
            else if (selectedItem.attr == Attribute.Map)
            {
                //DataControl.MapHold = true;
                dataStorage.mapHold = true;
                InventoryManager.UpdateItemInfo("地图读取成功 可以按下「M」键进行开关和使用");
            }
            else if (selectedItem.attr == Attribute.Coupon)
            {
                selectedItem.itemHeld -= 1;
                dataStorage.couponHold = true;
                InventoryManager.UpdateItemInfo("已使用能源券 飞船可以前往禹星");
            }
            else if (selectedItem.attr == Attribute.Trident)
            {
                dataStorage.tridentHold = true;
                InventoryManager.UpdateItemInfo("已装备三叉戟 可以在汤星表面的物质流中稳定自身");
            }
            else
            {
                InventoryManager.UpdateItemInfo("没有合适的时机使用该道具");
            }
        }
    }
}
