using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManuLoader : MonoBehaviour
{
    public Animator transition_;
    public float transitionTime = 1.5f;

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButton(0))
        //{
        
        //}
        if (Input.GetMouseButtonDown(0))
        {
            LoadStart();
        }

    }

    public void LoadStart()
    {
        StartCoroutine(LoadS(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadS(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);

        transition_.SetTrigger("StMTrigger");

        yield return new WaitForSeconds(transitionTime+1f);

        SceneManager.LoadScene(levelIndex);
    }
}
