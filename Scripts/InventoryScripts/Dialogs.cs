using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Dialog", menuName="Dialog/New Normal Dialog Block")]
public class Dialogs:ScriptableObject
{
    [TextArea]
    public string id;
}
