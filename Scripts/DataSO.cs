using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "new MCData", menuName = "Data/MCData")]
public class DataSO : ScriptableObject
{
    public float maxHealth = 50.0f;
    public float currentHealth = 50.0f;

    public float currentDamagePoints = 1.0f;

    public bool isTalking = false;

    public bool mapHold = false;

    public bool couponHold = false;

    public bool tridentHold = false;

    public int killNum = 0;
}
