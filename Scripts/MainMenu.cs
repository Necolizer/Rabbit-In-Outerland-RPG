using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition_;
    public float transitionTime = 1.5f;
    public GameObject EscPanel; //面板
    //private bool flag = false;

    public DataSO dataStorage;
    public AssinmentList alist;
    public Inventory inv;

    void Start()
    {
        if(EscPanel)
            EscPanel.SetActive(false);
    }

    public void LoadStart(int levelIndex)
    {
        StartCoroutine(LoadS(levelIndex));
    }

    IEnumerator LoadS(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);

        transition_.SetTrigger("StMTrigger");

        yield return new WaitForSeconds(transitionTime+1f);

        SceneManager.LoadScene(levelIndex);
    }

    public void NewGame()
    {
        initStatus();
        LoadStart(5);
    }

    public void GoToIntruduction()
    {
        LoadStart(2);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void GoToMainMenu()
    {
        LoadStart(1);
    }

    public void Optioin()
    {
        //if (!flag)
        //{
        //    EscPanel.SetActive(true);
        //    flag = true;
        //}
        //else
        //{
        //    EscPanel.SetActive(false);
        //    flag = false;
        //}
        EscPanel.SetActive(!EscPanel.activeSelf);
    }

    public void initStatus()
    {
        for (int i = 0; i < inv.itemList.Count; i++)
        {
            if (inv.itemList[i] == null)
                continue;
            if (inv.itemList[i].itemName == "Gun")
            {
                inv.itemList[i].itemHeld = 1;
            }
            else
            {
                inv.itemList[i].itemHeld = 0;
                inv.itemList[i] = null;
            }
        }

        for (int i = 0; i < alist.list_.Count; i++)
        {
            Debug.Log(alist.list_[i].currentID.ToString());
            alist.list_[i].currentID = 0;
        }

        dataStorage.maxHealth = 50.0f;
        dataStorage.currentHealth = 50.0f;

        dataStorage.currentDamagePoints = 1.0f;

        dataStorage.isTalking = false;
        dataStorage.mapHold = false;
        dataStorage.couponHold = false;
        dataStorage.tridentHold = false;

        dataStorage.killNum = 0;
    }

    public void Cancel()
    {
        EscPanel.SetActive(false);
        //flag = false;
    }
}
