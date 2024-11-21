using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deal : MonoBehaviour
{
    public GameObject HIButton;

    public GameObject DEALButton;

    public GameObject LOButton;
    public GameObject[] dealingCard;

    public GameObject Score;

    public int randomCard;

    public AudioSource dealCard;

    public GameObject time;

    public GameObject JokerButton;

    public void DealingNewCard()
    {
        //elapsed time text appears and starts
        time.SetActive(true);
        // generates random number corrosponding to card in deck
        randomCard = Random.Range(1, 53);

        // assined the value of randomCard to usedCards in the UsedCards script so that it cannot be picked again
        UsedCards.usedCards[randomCard] = randomCard;
        
        //the first card is dealt and the dealCard sound effect plays
        dealCard.Play();
        //assings the random number generated above to "dealingCard" and sets it to active
        //making it appear when deal is pressed
        dealingCard[randomCard].SetActive(true);

        //score text, hi button and lo button appears on the screen deal button disappears
        Score.SetActive(true);
        HIButton.SetActive(true);
        LOButton.SetActive(true);
        DEALButton.SetActive(false);
        JokerButton.SetActive(false);

        // passes the value of the "randomCard" card to the "ComparingCardValues" script 
        // use MOD 13 because value needs to be reset at the beginning of each suit
        // if card value is 13 then sends 13 instead of 0
        if (randomCard % 13 == 0)
        {
            ComparingCardValues.dealingCardValue = 13;
        }
        else
        {
           ComparingCardValues.dealingCardValue = randomCard % 13; 
        }
        
        ElapsedTime.playing = true;
    }


}
