using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIButton : MonoBehaviour
{
    

    public GameObject[] dealingCard;

    public int randomCard;

    public void DealingHICard()
    {
        //picks random number corrosponding to value of card by using the newCard() coroutine
        StartCoroutine(newCard());

        // assined the value of randomCard to usedCards in the UsedCards script so that it cannot be picked again
        UsedCards.usedCards[randomCard] = randomCard;

        //assings the random number generated above to "dealingCard" and sets it to active
        //making it appear on the right when HI is pressed
        dealingCard[randomCard].SetActive(true);



        // passes the value of the "randomCard" card to the "ComparingCardValues" script 
        // use MOD 13 because value needs to be reset at the beginning of each suit
        if (randomCard == 0){
            ComparingCardValues.newCardValue = 0;
            ComparingCardValues.newCardActualCard = randomCard;
        }
        else if (randomCard % 13 == 0)
        {
            ComparingCardValues.newCardValue = 13;
            ComparingCardValues.newCardActualCard = randomCard;
        }
        else
        {
            ComparingCardValues.newCardValue = randomCard % 13; 
            ComparingCardValues.newCardActualCard = randomCard;

        }


        //when the HI button is pressed the HI value in "ComparingCardValues" is set to true
        //
        ComparingCardValues.HI = true;
        
    }

    IEnumerator newCard(){
        //picks random number corrosponding to value of card
        //if the joker button has been pressed then the joker can be used
        if (Joker.jokerOn == true){
            randomCard = Random.Range(0, 53);
        }else {
            randomCard = Random.Range(1, 53);
        }
        
        //checks the usedCards array in the UsedCards script to see if the card has already been used
        while (UsedCards.usedCards[randomCard] == randomCard){
            //uses recursion until a non used card is found 
            StartCoroutine(newCard());
        }

        yield return new WaitForSeconds(0);
    }
}
