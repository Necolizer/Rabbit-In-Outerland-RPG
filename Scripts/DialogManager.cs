using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public string PassedDialog;
    public Text Lines;
    private int currentDialogNumber;
    private int n_stage;
    private int next_stage;
    // Start is called before the first frame update
    void Start()
    {
        PassedDialog = "-1";
        Debug.Log(PassedDialog);
        Frost();
        // currentDialogNumber = PassedDialog.idx;
        // n_stage = PassedDialog.stage[currentDialogNumber];
        // next_stage = PassedDialog.stage[currentDialogNumber + 1];
        // Lines.text = PassedDialog.dialogTexts[n_stage];
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PassedDialog);
        Forward();
    }

    void Frost()
    {
        //TODO:
        // Implement your code here
    }

    void Forward()
    {
        if(Input.GetKeyDown(KeyCode.F) && n_stage < next_stage)
        {
            n_stage++;
            // Lines.text = PassedDialog.dialogTexts[n_stage];
        }
        // else if(Input.GetKeyDown(KeyCode.F) && n_stage >= PassedDialog.dialogTexts.Count - 1)
        // {
            // currentDialogNumber = 0;
            // PassedDialog.idx++;
            // ActiveAll(true);
        // }
        else if(Input.GetKeyDown(KeyCode.F) && n_stage >= next_stage)
        {
            currentDialogNumber = 0;
            // PassedDialog.idx++;
            ActiveAll(false);
        }
    }

    void ActiveAll(bool kill)
    {
        //TODO:
        // Implement your code here
        if(kill == true)
        {
            Destroy(this);
        }
    }

    public void SetIdMsg(string Id)
    {
        PassedDialog = Id;
    }

    void Decoder()
    {

    }

    void Reader()
    {

    }
}
