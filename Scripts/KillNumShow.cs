using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillNumShow : MonoBehaviour
{
    public DataSO dataStorage;
    public Text num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        num.text = dataStorage.killNum.ToString();
    }
}
