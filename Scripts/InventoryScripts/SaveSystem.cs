using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Save System", menuName="SaveSystem/New Save System")]
public class SaveSystem : ScriptableObject
{
    // [TextArea]
    public List<CheckpointsSystem> Ckpt = new List<CheckpointsSystem>();
    public CheckpointsSystem ckpt_current;
    // public float CharacterHealth;

}
