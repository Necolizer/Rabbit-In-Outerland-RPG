using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogTrigger : MonoBehaviour
{
    public GameObject dialog;
    public GameObject DialogBlock;
    public float maxScale;
    public float scaleSpeed;
    private bool UpdateScale;
    public GameObject TopicMark;
    public GameObject AskMark;
    public Assignment assign;
    public DataSO dataStorage;
    // public string NPCDialog;
    // Start is called before the first frame update
    void Start()
    {
        dialog.transform.localScale = Vector3.zero;
        AskMark.SetActive(false);
        TopicMark.SetActive(true);
    }
    // private void OnEnable() {
    //     Fix();
    // }
    private void FixedUpdate() {
        Fix();
    }
    private void Fix() {
        if(assign.missionDatas[assign.currentID].next_id == assign.currentID)
        {
            EndTopic();
        }else if(!assign.missionDatas[assign.currentID].isFinish && assign.currentID != 0)
        {
            ExitDialog();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(UpdateScale == true && dialog.transform.localScale.x < maxScale)
        {
            dialog.transform.localScale += Vector3.one * Time.deltaTime * scaleSpeed;
        }
        else if(UpdateScale == false && dialog.transform.localScale.x > 0)
        {
            dialog.transform.localScale -= Vector3.one * Time.deltaTime * scaleSpeed;
        }

        if(UpdateScale == true)
        {
            if (Input.GetKeyDown(KeyCode.F) && DialogBlock.activeSelf == false)
            {
                DialogBlock.SetActive(true);
                dataStorage.isTalking = true;
                // DialogBlock.GetComponent<DialogManager>().SetIdMsg(NPCDialog);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D player)
    {
        if (
            player.gameObject.CompareTag("Player")
            && player.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
        )
        {
            UpdateScale = true;
            // if(playerHealth != null)
            // {
            //     playerHealth.DamagePlayer(damage);
            // }
        }
    }

    public void OnTriggerExit2D(Collider2D player)
    {
        if(
            player.gameObject.CompareTag("Player")
            && player.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
        )
        {
            UpdateScale = false;
        }
    }

    public void ExitDialog()
    {
        TopicMark.SetActive(false);
        AskMark.SetActive(true);
    }

    public void EndTopic()
    {
        TopicMark.SetActive(false);
        AskMark.SetActive(false);
    }
}
