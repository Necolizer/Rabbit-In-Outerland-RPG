using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    public Item keyitem;
    public Animator transition_;
    public float transitionTime = 1.5f;
    public GameObject Flag;

    public void LoadStart(int levelIndex)
    {
        Cursor.visible = true;
        StartCoroutine(LoadS(levelIndex));
    }

    IEnumerator LoadS(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);

        transition_.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime + 1f);

        SceneManager.LoadScene(levelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (keyitem.itemHeld >= 1 && Flag.activeSelf)
        {
            LoadStart(3);
        }
    }
}
