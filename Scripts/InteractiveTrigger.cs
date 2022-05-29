using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveTrigger : MonoBehaviour
{
    public GameObject SomethingBlock;
    public GameObject SthNewBlock;
    public GameObject AskMark;
    public GameObject pointer;
    private bool UpdateScale = false;
    public DataSO dataStorage;
    //public bool needCursor = true;

    // Start is called before the first frame update
    void Start()
    {
        AskMark.SetActive(true);
    }

    //private void FixedUpdate()
    //{
    //    Fix();
    //}
    //private void Fix()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (UpdateScale == true)
        {
            if (Input.GetKeyDown(KeyCode.F) && SomethingBlock.activeSelf == false)
            {
                SomethingBlock.SetActive(true);
                //if (needCursor)
                //{
                dataStorage.isTalking = true;
                Cursor.visible = true;
                if (pointer)
                    pointer.SetActive(false);
                //}
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
        }
    }

    public void OnTriggerExit2D(Collider2D player)
    {
        if (
            player.gameObject.CompareTag("Player")
            && player.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
        )
        {
            UpdateScale = false;
        }
    }

    public void notYetDone()
    {
        if (SomethingBlock.activeSelf)
            SomethingBlock.SetActive(false);
        //DataControl.setActing(false);
        dataStorage.isTalking = false;
        Cursor.visible = false;
        if (pointer)
            pointer.SetActive(true);
    }

    public void isDone()
    {
        if (SomethingBlock.activeSelf)
            SomethingBlock.SetActive(false);
        AskMark.SetActive(false);
        //DataControl.setActing(false);
        dataStorage.isTalking = false;
        Cursor.visible = false;
        if (pointer)
            pointer.SetActive(true);
        if (!SthNewBlock.activeSelf)
        {
            SthNewBlock.SetActive(true);
        }
    }
}

