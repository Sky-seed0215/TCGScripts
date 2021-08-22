using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IbeginDragHandler, IEndDragHandler
{
    public Transform cardParent;

    public void OnBeginDrag(PointerEventData eventData) //Processing when starting dragging.
    {
        cardParent = transform.parent;
        transform.SetParent(cardParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false; //Turn off Blocks Raycasts.
    }

    public void OnDrag(PointerEventData eventData) //What happens when you drag.
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) //What to do when you release the card.
    {
        transform.SetParent(cardParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true; //Turn on Blocks Raycasts.
    }
}
