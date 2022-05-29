using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;

	private bool click = false;

    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1 || click)
			{
				click = false;
				animator.SetBool ("pressed", true);
			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}else{
			animator.SetBool ("selected", false);
		}
    }

	public void OnPointerEnter(PointerEventData eventData)
	{
		menuButtonController.index = thisIndex;
        if (animator.GetBool("pressed"))
        {
            animator.SetBool("pressed", false);
            animatorFunctions.disableOnce = true;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
		click = true;
	}
	public void OnPointerExit(PointerEventData eventData)
	{

	}
}
