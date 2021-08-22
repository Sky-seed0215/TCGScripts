using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public CardView view; //How the card looks.
    public CardModel model; //Process card data.

    private void Awake() {
        view = GetComponent<CardView>();
    }

    public void Init(int cardID) //Function called when the card is generated.
    {
        model = new CardModel(cardID); //Generate card data.
        view.Show(model); //Display the result of processing.
    }
}
