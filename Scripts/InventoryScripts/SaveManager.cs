using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    
    public CheckpointsSystem ckpt_current;
    public SaveSystem save;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public float CharacterHealth;

    void InsertToSave(int SaveId, string SaveName)
    {
        ckpt_current.GameTime = System.DateTime.Now;
        if(SaveId == 0)
        {
            // append into last
            // CheckpointsSystem new_ckpt = new CheckpointsSystem();
            // new_ckpt = ckpt_current;
            if(SaveName == null){
                ckpt_current.SaveName = string.Concat("Save", SaveId.ToString());
            }
            save.Ckpt.Add(ckpt_current);
        }else
        {
            if(SaveName != null)
            {
                ckpt_current.SaveName = SaveName;
            }
            save.Ckpt[SaveId]= ckpt_current;
        }
    }
}
