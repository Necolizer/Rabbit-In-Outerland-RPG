using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MangaReader : MonoBehaviour
{
    public Animator transition_;
    public float transitionTime = 1.5f;

    public GameObject m1;
    public GameObject m2;
    private bool ok = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        m1.SetActive(true);
        m2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ok)
        {
            Invoke("nextPage", 3);
        }else if (Input.GetMouseButtonDown(0) && ok)
        {
            LoadStart(6);
        }
    }

    void nextPage()
    {
        m1.SetActive(false);
        m2.SetActive(true);
        ok = true;
    }

    public void LoadStart(int levelIndex)
    {
        StartCoroutine(LoadS(levelIndex));
    }

    IEnumerator LoadS(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);

        transition_.SetTrigger("StMTrigger");

        yield return new WaitForSeconds(transitionTime + 1f);

        SceneManager.LoadScene(levelIndex);
    }
}
