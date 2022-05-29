using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Begining : MonoBehaviour
{
    [Header("UI Component")]
    public Text textLabel;

    [Header("Text File")]
    private TextAsset textFile;
    private DialogSystem dialog;

    [Header("Background")]
    public GameObject background;
    public Sprite PlayerBackground;
    public Sprite NPCBackground;
    [Header("Assignment")]
    private int id;
    public Assignment assign;
    public Inventory inv;

    [Header("Parameters")]
    public int textStart;
    private int textEnd;
    public float textSpeed;

    private int textIndex;
    private bool isFinish = false;
    private bool conditionVariable;
    private bool PrintLine;
    private Image bgImage;
    List<string> textList = new List<string>();
    // Start is called before the first frame update

    void Start()
    {
        id = assign.currentID;
        RefreshFile();
    }
    void Awake()
    {
        id = assign.currentID;
        // CheckCondition();
        RefreshFile();
        // Debug.Log("textIndex:"+textIndex.ToString());
        // textLabel.text = textList[textIndex];
        // textIndex++;
        
    }
    private void OnEnable() {
        id = assign.currentID;
        CheckCondition();
        RefreshFile();
        textIndex = textStart;
        StartCoroutine(SetTextUI(textSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        if(id == assign.missionDatas[id].next_id)
        {
            id++;
            gameObject.SetActive(false);
        }
        CheckCondition();
        
        bool cond = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1);
        if(cond && textIndex >= textEnd)
        {
            textIndex = textStart;
            RefreshFile();
            // DataControl.setActing(false);
            // gameObject.SetActive(false);
        }
        else if(cond && PrintLine == true)
        {
            // textLabel.text = textList[textIndex];
            // textIndex++;
            StartCoroutine(SetTextUI(textSpeed));
        }else if(Input.GetKey(KeyCode.LeftControl) && textIndex >= textEnd)
        {
            textIndex = textStart;
            RefreshFile();
            // DataControl.setActing(false);
            // gameObject.SetActive(false);
        }
        else if(Input.GetKey(KeyCode.LeftControl) && PrintLine == true)
        {
            // textLabel.text = textList[textIndex];
            // textIndex++;
            StartCoroutine(SetTextUI(200));
        }
        // else if(id < 5)
        // {
        //     StartCoroutine(SetTextUI(textSpeed));
        // }
    }
    private void CheckCoroutine()
    {
        
        CheckCondition();
        RefreshFile();
        if(id == assign.missionDatas[id].next_id)
        {
            id++;
            Destroy(this);
        }
        // yield return new WaitForSeconds(10f);
    }
    void getTextFromFile(TextAsset File)
    {
        textList.Clear();
        textIndex = textStart;
        var lineSplit = File.text.Split('\n');

        foreach (var item in lineSplit)
        {
            textList.Add(item);
        }
        textEnd = textList.Count;
    }

    void getTextFromObject(DialogSystem diasys)
    {
        textList.Clear();
        textIndex = diasys.stage[0];
        foreach (var text in diasys.dialogTexts)
        {
            textList.Add(text);
        }
    }

    IEnumerator SetTextUI(float speed)
    {
        PrintLine = false;
        textLabel.text = "";
        for (int i = 0; i < textList[textIndex].Length; i++)
        {
            textLabel.text += textList[textIndex][i];

            yield return new WaitForSeconds(1/speed);
        }
        if (PrintLine != true)
        {
            PrintLine = true;
            textIndex++;
        }
    }

    private void RefreshFile()
    {
        if(isFinish == true)
        {
            // if (id == assign.missionDatas[id].next_id)
            // {
            //     dialogTrigger.EndTopic();
            // }else
            // {
            //     dialogTrigger.ExitDialog();
            // }
            id = assign.missionDatas[id].next_id;
            assign.currentID = id;
            isFinish = false;
        }
        textFile = assign.missionDatas[id].file;
        if (textFile != null)
        {
            getTextFromFile(textFile);
        }else if(dialog != null)
        {
            getTextFromObject(dialog);
        }
    }
    private void CheckCondition(){
        if(id == 0)
        {
            if((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
            {
                isFinish = true;
            }
        }else if(id == 1)
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                isFinish = true;
            }
        }else if(id == 2)
        {
            isFinish = true;
        }else if(id == 3)
        {
            if(Input.GetMouseButtonDown(0))
            {
                isFinish = true;
            }
        }else if(id == 4)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                isFinish = true;
            }
        }
        else if(id == 5)
        {
            isFinish = true;
        }
        else if(id == 6)
        {
            Check();
        }
        else if(id == 7)
        {
            isFinish = true;
        }
    }
    private void Check()
    {
        Item require = assign.missionDatas[id].require_;
            int requireCount = assign.missionDatas[id].require.itemCount;
            if(require.itemHeld >= requireCount)
            {
                require.itemHeld -= requireCount;
                if(require.itemHeld == 0)
                {
                    //inv.itemList.Remove(require);
                    for (int i = 0; i < inv.itemList.Count; i++)
                    {
                        if (inv.itemList[i] == require)
                        {
                            inv.itemList[i] = null;
                            break;
                        }
                    }
                }
                isFinish = true;
                SetCondition();
            }
    }
    private void SetCondition()
    {
        Item rewards = assign.missionDatas[id].rewards_;
        int rewardsCount = assign.missionDatas[id].rewards.itemCount;
        if(inv.itemList.Contains(rewards)== false)
        {
            //inv.itemList.Add(rewards);
            for (int i = 0; i < inv.itemList.Count; i++)
            {
                if (inv.itemList[i] == null)
                {
                    inv.itemList[i] = rewards;
                    rewards.itemHeld += rewardsCount;
                    break;
                }
            }
        }
        isFinish = true;
        InventoryManager.RefreshItem();
    }
}
