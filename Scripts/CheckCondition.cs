using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCondition : MonoBehaviour
{
    public Item sth;
    public GameObject sb;
    private bool isOK = false;

    // Update is called once per frame
    void Update()
    {
        if(sth.itemHeld == 1 && !isOK)
        {
            sb.SetActive(true);
            isOK = true;
        }
    }
}
