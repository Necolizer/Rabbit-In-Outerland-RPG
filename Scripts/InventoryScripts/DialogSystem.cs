using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Dialogs", menuName="Dialog/New Dialog Lists")]
public class DialogSystem : ScriptableObject
{
    public int idx;
    public List<int> stage;
    [TextArea]
    public List<string> dialogTexts;
}
