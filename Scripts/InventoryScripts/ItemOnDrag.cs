using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent;
    public Inventory PlayerBag;
    private int currentItemID;//当前物品ID

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        currentItemID = originalParent.GetComponent<Slot>().slotID;
        transform.SetParent(transform.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!eventData.pointerCurrentRaycast.gameObject)
        {
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }

        if (eventData.pointerCurrentRaycast.gameObject.name != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "Item Image")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                var temp = PlayerBag.itemList[currentItemID];
                PlayerBag.itemList[currentItemID] = PlayerBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];
                PlayerBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;


                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }

            if (eventData.pointerCurrentRaycast.gameObject.name == "slot(Clone)")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                PlayerBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = PlayerBag.itemList[currentItemID];

                if (eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID != currentItemID)
                    PlayerBag.itemList[currentItemID] = null;

                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }

        transform.SetParent(originalParent);
        transform.position = originalParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
