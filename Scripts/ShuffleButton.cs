using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ShuffleButton : MonoBehaviour
{
    public AudioSource shuffle;

    public GameObject score;

    public GameObject time;


    public void ShuffleDeck()
    {
        //score text is set back to 0
        KeepScore.score = 0;
        //when the shuffle button is pressed the score text disappears and shffle sound effect plays
        score.SetActive(false);
        shuffle.Play();

        //the elapsed time text disappears 
        time.SetActive(false);

        //tells the "ComparingCardValues" script that the shuffle button has been pressed
        ComparingCardValues.shuffle = true;

        //turns the joker off as the defualt value is off
        Joker.jokerOn = false;

        //resets usedCards in the UsedCards script so that all of the cards are available again
        for (int i = 0; i < 53; i++){
            UsedCards.usedCards[i] = -1;
        }
    }

        
}
