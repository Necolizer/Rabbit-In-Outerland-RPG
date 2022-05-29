using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ESCPanel : MonoBehaviour
{
	public Animator transition_;
	public float transitionTime = 1.5f;

	
	public DataSO dataStorage;
	public AssinmentList alist;
	public Inventory inv;

	public void LoadStart(int levelIndex)
	{
		StartCoroutine(LoadS(levelIndex));
	}

	IEnumerator LoadS(int levelIndex)
	{
		yield return new WaitForSeconds(transitionTime);

		transition_.SetTrigger("Start");

		yield return new WaitForSeconds(transitionTime + 1f);

		SceneManager.LoadScene(levelIndex);
	}

	public GameObject EscPanel; //面板
	private bool flag = false;
	public GameObject OptionPanel; //面板
	private bool Oflag = false;

	// Use this for initialization

	void Start()
	{
		EscPanel.SetActive(false);
		OptionPanel.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!flag)
			{
				EscPanel.SetActive(true);
				flag = true;
			}
			else
			{
				EscPanel.SetActive(false);
				flag = false;
			}
		}
	}

	public void Cancel()
	{
		EscPanel.SetActive(false);
		flag = false;
	}

	public void ReStart()
	{
		initStatus();
		LoadStart(6);
	}

	public void ExitButton()
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
		if (!Oflag)
		{
			OptionPanel.SetActive(true);
			Oflag = true;
		}
		else
		{
			OptionPanel.SetActive(false);
			Oflag = false;
		}
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
	public void OCancel()
	{
		OptionPanel.SetActive(false);
		Oflag = false;
	}
}
