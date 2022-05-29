using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public Sprite highHP, lowHP;
    public Image HPSlider;
    public GameObject lowHPCover;
    public DataSO dataStorage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float maxHp = dataStorage.maxHealth;//DataControl.MyMaxHealth;
        float currHp = dataStorage.currentHealth;//DataControl.MyCurrentHealth;
        Slider slider = GetComponent<Slider>();
        slider.value = currHp / maxHp;
        if(slider.value < 0.5f)
        {
            HPSlider.sprite = lowHP;
        }else
        {
            HPSlider.sprite = highHP;
        }
        text.text = currHp.ToString() + "/" + maxHp.ToString();

        lowHPCover.SetActive(slider.value < 0.25f);
    }
}
