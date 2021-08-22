using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    [SerializeField] Transform playerHand, playerField, enemyField;

    bool isPlayerTurn = true;
    List<int> deck = new List<int>() { 1, 2, 3, 1, 1, 2, 2, 3, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3 };

    void start()
    {
        StartGame();
    }

    void StartGame() //Initial value setting.
    {
        SetStartHand(); //Distribute your initial hand.
        TurnCalc(); //Turn decision.
    }

    void CreateCard(int cardID, Transform place)
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID);
    }

    void DrowCard(Transform hand) //Draw a card.
    {
        //If you don't have a deck, don't pull.
        if (deck.Count == 0)
        {
            return;
        }

        CardController[] playerHandCardList = playerHand.GetComponentsInChildren<CardController>();

        if (playerHandCardList.Length < 9)
        {
            //Remove the top card from your deck and add it to your hand.
            int cardID = deck[0];
            deck.RemoveAt(0);
            CreateCard(cardID, hand);
        }
    }

    void SetStartHand() //Deal three cards in your hand.
    {
        for (int i = 0; i < 3; i++)
        {
            DrowCard(playerHand);
        }
    }

    void TurnCalc() //Manage turns.
    {
        if (isPlayerTurn)
        {
            PlayerTurn();
        }
        else
        {
            EnemyTrun();
        }
    }

    public void ChangeTurn() //Processing to attach to the turn end button.
    {
        isPlayerTurn = !isPlayerTurn; //Reverse the turn.
        TurnCalc(); //Turn to the opponent.
    }

    void PlayerTurn()
    {
        Debug.Log("Player's turn.");

        DrowCard(playerHand); //Add a card from your hand.
    }

    void EnemyTurn()
    {
        Debug.Log("Enemy's turn.");

        CardController[] enemyFieldCardList = enemyField.GetComponentsInChildren<CardController>();

        if (enemyFieldCardList.Length < 5)
        {
            CreateCard(1, enemyField); //Summon a card.
        }

        ChangeTurn(); //Turn end.
    }
}
/*
void start()
{
    for (int i = 0; i < value; i++)
    {
        // Ory one hand (self)
        Instantiate(cardPrefab, playerHand);
    }
    for (int i = 0; i < value; i++)
    {
        //Three fields in the field (self)
        Instantiate(cardPrefab, playerField);
    }
    for (int i = 0; i < value; i++)
    {
        //Two fields in the field (enemy)
        Instantiate(cardPrefab, enemyField);
    }
}
*/
