using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AssignType
{
    ItemId,
    // Gold,
}
[System.Serializable]
public struct AssignmentType
{
    public int itemCount;
}
[System.Serializable]
public struct AssignmentData
{
    // [Header("description")]
    // public string des;
    [Header("mission id")]
    public int id;
    public int next_id;
    [Header("finished?")]
    public bool isFinish;
    [Header("text file")]
    public TextAsset file;
    [Header("item")]
    
    public AssignmentType require;
    public Item require_;
    public AssignmentType rewards;
    public Item rewards_;
}
[System.Serializable]
[CreateAssetMenu(fileName="new Mission", menuName="MissionData/new Mission")]
public class Assignment:ScriptableObject
{
    public int currentID = 0;
    public List<AssignmentData> missionDatas;
}
// [System.Serializable]