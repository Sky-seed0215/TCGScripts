using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Class to attach to the field.
public class DropPlace : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) //What to do when dropped.
    {
        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>(); //Get Card Movement from the dragged information.
        if (card != null) //If you have a card,
        {
            card.cardParent = this.transform; //Make the parent element of the card yourself (attached object).
        }
    }
}
