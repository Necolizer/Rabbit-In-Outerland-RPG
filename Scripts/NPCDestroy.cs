using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestroy : MonoBehaviour
{
    public GameObject diablock;
    public Assignment assign;
    public List<GameObject> s;
    public List<GameObject> nextlist;
    public int type = 0;
    public List<GameObject> requireShowList;
    private bool isOK = false;
    private bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(assign.missionDatas[assign.currentID].next_id == assign.currentID && !diablock.activeSelf && !done)
        {
            for (int i = 0; i < s.Count; i++)
            {
                s[i].SetActive(false);
            }
            for(int i = 0; i < nextlist.Count; i++)
            {
                nextlist[i].SetActive(true);
            }
            done = true;
        }
        if(type == 1 && !isOK && diablock.activeSelf)
        {
            for (int i = 0; i < requireShowList.Count; i++)
            {
                requireShowList[i].SetActive(true);
            }
            isOK = true;
        }
    }
}
