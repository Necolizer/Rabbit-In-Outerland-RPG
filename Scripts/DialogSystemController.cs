using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystemController : MonoBehaviour
{
    public DataSO dataStorage;

    [Header("UI Component")]
    public Text textLabel;

    [Header("Text File")]
    public TextAsset textFile;
    public DialogSystem dialog;

    [Header("Background")]
    public GameObject background;
    public Sprite PlayerBackground;
    public Sprite NPCBackground;

    [Header("Parameters")]
    public int textStart;
    public int textEnd;
    public float textSpeed;

    private int textIndex;
    private bool conditionVariable;
    private bool PrintLine;
    private Image bgImage;
    List<string> textList = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        if (textFile != null)
        {
            getTextFromFile(textFile);
        }else if(dialog != null)
        {
            getTextFromObject(dialog);
        }
        // Debug.Log("textIndex:"+textIndex.ToString());
        // textLabel.text = textList[textIndex];
        // textIndex++;
        
    }
    private void OnEnable() {
        textIndex = textStart;
        StartCoroutine(SetTextUI(textSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        bool cond = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1);
        if(cond && textIndex >= textEnd)
        {
            textIndex = textStart;
            // dialogTrigger.EndTopic();
            gameObject.SetActive(false);
            //DataControl.setActing(false);
            dataStorage.isTalking = false;
        }
        else if(cond && PrintLine == true)
        {
            // textLabel.text = textList[textIndex];
            // textIndex++;
            StartCoroutine(SetTextUI(textSpeed));
        }else if(Input.GetKey(KeyCode.LeftControl) && textIndex >= textEnd)
        {
            textIndex = textStart;
            // dialogTrigger.EndTopic();
            gameObject.SetActive(false);
            //DataControl.setActing(false);
            dataStorage.isTalking = false;
        }
        else if(Input.GetKey(KeyCode.LeftControl) && PrintLine == true)
        {
            // textLabel.text = textList[textIndex];
            // textIndex++;
            StartCoroutine(SetTextUI(200));
        }
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
        // if(textIndex > textList.Count)
        // {
        //     yield return new WaitForSeconds(textSpeed);
        // }
        PrintLine = false;
        textLabel.text = "";
        // switch(textList[textIndex]){
        //     case "Player":
        //         bgImage = background.GetComponent<Image>();
        //         bgImage.sprite = PlayerBackground;
        //         textIndex++;
        //         break;
        //     case "NPC":
        //         bgImage = background.GetComponent<Image>();
        //         bgImage.sprite = NPCBackground;
        //         textIndex++;
        //         break;
        // }
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
    void CheckAndSet()
    {

    }
}
