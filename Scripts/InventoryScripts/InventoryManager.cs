using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory PlayerBag;
    public GameObject slotGrid;
    //public Slot slotPrefab;
    public GameObject emptySlot;
    public Text itemInfomation;

    public List<GameObject> slots = new List<GameObject>();

    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInfomation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInfomation.text = itemDescription;
    }

    //public static void CreateNewItem(Item item)
    //{
    //    Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
    //    newItem.gameObject.transform.SetParent(instance.slotGrid.transform, false);
    //    newItem.slotItem = item;
    //    newItem.slotImage.sprite = item.itemImage;
    //    newItem.slotNum.text = item.itemHeld.ToString();
    //}

    public static void RefreshItem()
    {
        for(int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for (int i = 0; i < instance.PlayerBag.itemList.Count; i++)
        {
            //CreateNewItem(instance.PlayerBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform, false);
            instance.slots[i].GetComponent<Slot>().slotID = i;
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.PlayerBag.itemList[i]);
        }
    }
}
