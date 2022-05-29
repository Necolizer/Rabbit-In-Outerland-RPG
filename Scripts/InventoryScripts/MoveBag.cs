using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MoveBag : MonoBehaviour, IDragHandler
{
    RectTransform currentRect;
    public GameObject pointer;

    void Awake()
    {
        currentRect = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        currentRect.anchoredPosition += eventData.delta;
    }

    void OnEnable()
    {
        Cursor.visible = true;
        pointer.SetActive(false); 
        Time.timeScale = 0;
    }

    void OnDisable()
    {
        Time.timeScale = 1f;
        pointer.SetActive(true);
        Cursor.visible = false;
    }
}
