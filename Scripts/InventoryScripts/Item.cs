using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attribute
{
    Gun,
    Healer,
    Other,
    Map,
    Coupon,
    Trident,
}
[System.Serializable]

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    [Header("物品属性/类别")]
    public Attribute attr;
    [Header("物品数据(Gun时为攻击,Healer时为治疗量,Other时无作为)")]
    public float param;
    [Header("物品名称")]
    public string itemName;
    [Header("物品图片")]
    public Sprite itemImage;
    [Header("物品持有量,初始化为0")]
    public int itemHeld;
    [Header("物品信息")]
    [TextArea]
    public string itemInfo;
    [Header("是否可删除")]
    public bool deleteable;
}
