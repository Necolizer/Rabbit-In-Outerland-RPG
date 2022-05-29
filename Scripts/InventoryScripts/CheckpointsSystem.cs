using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Checkpoints System", menuName="SaveSystem/New Checkpoints")]
public class CheckpointsSystem : ScriptableObject
{
    // public Bag MyBag;
    // public Location Currentlocate;
    public int MyBag;
    public int Currentlocation;
    public int CurrentSceneID;
    public float CharacterHealth;
    public System.DateTime GameTime;
    public string SaveName;
    

}
