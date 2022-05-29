using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapControl : MonoBehaviour
{
    public GameObject map;
    public DataSO dataStorage;
    public GameObject pointer;
    public GameObject btn3;
    public GameObject btn4;

    public Animator transition_;
    public float transitionTime = 1.5f;

    public void LoadStart(int levelIndex)
    {
        jump();
        StartCoroutine(LoadS(levelIndex));
    }

    IEnumerator LoadS(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);

        transition_.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime + 1f);

        SceneManager.LoadScene(levelIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dataStorage.mapHold && Input.GetKeyDown(KeyCode.M))
        {
            map.SetActive(!map.activeSelf);
            dataStorage.isTalking = map.activeSelf;
            Cursor.visible = map.activeSelf;
            pointer.SetActive(!map.activeSelf);
            Time.timeScale = map.activeSelf ? 0 : 1f;
        }
        if (map.activeSelf)
        {
            btn3.SetActive(dataStorage.couponHold);
            btn4.SetActive(dataStorage.tridentHold);
        }
    }

    public void resumeBtn()
    {
        map.SetActive(!map.activeSelf);
        dataStorage.isTalking = map.activeSelf;
        Cursor.visible = map.activeSelf;
        pointer.SetActive(!map.activeSelf);
        Time.timeScale = map.activeSelf ? 0 : 1f;
    }

    public void jump()
    {
        dataStorage.isTalking = false;
        Time.timeScale = 1f;
    }
}
