using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    public CheckpointsSystem current;
    public SaveSystem save;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitSystem(int SaveId)
    {
        CheckpointsSystem loadCkpt = save.Ckpt[SaveId];
        current.MyBag = loadCkpt.MyBag;
        current.Currentlocation = loadCkpt.Currentlocation;
        current.CurrentSceneID = loadCkpt.CurrentSceneID;
        current.CharacterHealth = loadCkpt.CharacterHealth;
        current.GameTime = System.DateTime.Now;
    }

    void ExitSystem()
    {
        // MyBag.ExitSystem();
        // locate.ExitSystem();
        current.CharacterHealth = 0.0f;
    }

    // void Copy(CheckpointsSystem ckpt)
    // {
    //     current.MyBag = ckpt.MyBag;
    //     current.Currentlocation = ckpt.Currentlocation;
    //     current.CurrentSceneID = ckpt.CurrentSceneID;
    //     current.CharacterHealth = ckpt.CharacterHealth;
    //     current.GameTime = ckpt.GameTime;
    //     current.SaveName = ckpt.SaveName;
    // }
}
