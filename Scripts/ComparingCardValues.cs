using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComparingCardValues : MonoBehaviour
{
   public GameObject[] LeftCards;
   public GameObject[] RightCards;
   

   public static int dealingCardValue;

   public static int[] cards = new int[53]; //array to track the used cards

   public static int newCardValue; //numeric value of the newCard (1-13, ace to king)
   public static int newCardActualCard; //actual value of the card in the deck (1-52)

   public GameObject winner;

   public GameObject loser;

   public static bool shuffle = false;

   public static bool LO = false;
   public static bool HI = false;
   public static bool doublePoints = false;
   
   //cards played is always at least 1 because of the first card
   public static int cardsPlayed = 1;

   public GameObject LOButton;
   public GameObject HIButton;
   public GameObject DEALButton;
   public GameObject ShuffleButton;
   public GameObject JokerButton;
   public GameObject champion;
   public AudioSource finalSound;

   public AudioSource rightGuess;

   public AudioSource wrongGuess;

   public AudioSource dealCard; 



   //if the same card number is drawn then it counts as higher
   void Update()
   {
      //if the full deck has been played this code runs
      if(cardsPlayed == 53){
         //reduendancy to ensure all variables are reset
         HI = false;
         LO = false;
         //turns off the HI and LO buttons when the game is won
         //then starts the HIguess coroutine
            HIButton.SetActive(false);
            LOButton.SetActive(false);
         

         StartCoroutine(Champion());
         cardsPlayed = 1;

      }

      //if there are still cards to be played this code runs
      else{
         //This double if can be used because the nature of the program requires
         //either the HI or LO button to be pressed
         if (HI == true)
         {
            //the HI card guess has been selected and the dealCard sound effect plays
            dealCard.Play();
            //turns off the HI and LO buttons when the HI button is pressed
            //then starts the HIguess coroutine 
            HIButton.SetActive(false);
            LOButton.SetActive(false);
            StartCoroutine(HIGuess());
            //HI button set back to false to terminate (avoid infinite loop)
            HI = false;
         }

         if (LO == true)
         {
            //the LO card guess has been selected and the dealCard sound effect plays
            dealCard.Play();
            //turns off the HI and LO buttons when the LO button is pressed
            //then starts the LOguess coroutine 
            HIButton.SetActive(false);
            LOButton.SetActive(false);
            StartCoroutine(LOGuess());
            //LO button set back to false to terminate (avoid infinite loop)
            LO = false;
         }

      }
      
      if (shuffle == true)
      {
         //turns off the shuffle button when it's pressed and runs the "shufflethat" coroutine
         ShuffleButton.SetActive(false);
         StartCoroutine(Shufflethat());
         //shuffle button set back to false to terminate (avoid infinite loop)
         shuffle = false;
      }
   
   }

   //shuffle coroutine
   //resets the right and LeftCardst decks for a new game so that all of the cards are available
   IEnumerator Shufflethat()
   { 
      yield return new WaitForSeconds(1);
      for (int i = 1; i <= 52; i++)
      {
         LeftCards[i].SetActive(false);
         RightCards[i].SetActive(false);
      }
      //deal button reappears to start a new game
      DEALButton.SetActive(true);   
      //turns joker button back on so the user can decide to activate it 
      JokerButton.SetActive(true);
      //turns jokerOn in the joker script off so it is deactiated
      Joker.jokerOn = false;
   }
   
   //HIGuess coroutine
   IEnumerator HIGuess()
   {
      //delays the program for 1 second (time until "You're right / wrong" text appears on screen)
      yield return new WaitForSeconds(1);

      //if the card is a joker
      if (newCardValue == 0){
         //increments the number of cards played by 1 to keep track of prgression (for termination)
         cardsPlayed += 1;
         if (cardsPlayed == 53){
            HIButton.SetActive(false);
            LOButton.SetActive(false);
            yield break;
         }

         doublePoints = true;

         //joker dissapears
         for (int i = 0; i <= 52; i++)
         {
            RightCards
      [i].SetActive(false);
         }

         //Turning HI and LO button back on so user can guess again
         HIButton.SetActive(true);
         LOButton.SetActive(true);
         yield break;
      }

      // if the walue of the new card is greater than or equal to the value of the original card then the 
      //winner text is displayed, otherwise the loser text is displayed
      else if(newCardValue >= dealingCardValue)
      {
         //tells the KeepScore script that the user has won another point if joker is active then double points are on and the user gets 2 points
         if (doublePoints == true){
            KeepScore.score += 2;
         }else{
            KeepScore.score += 1;
         }

         //increments the number of cards played by 1 to keep track of prgression (for termination)
         cardsPlayed += 1;
         if (cardsPlayed == 53){
            HIButton.SetActive(false);
            LOButton.SetActive(false);
            yield break;
         }
   
         //if the HI guess is correct then the "you're right" text appears for 2 seconds and the rightGuess audio plays
         winner.SetActive(true);
         rightGuess.Play();
         yield return new WaitForSeconds(2);
         winner.SetActive(false);
         //if the HI guess is correct then the cards on the LeftCardst and right stack disapear
         for (int i = 1; i <= 52; i++)
         {
            LeftCards[i].SetActive(false);
            RightCards[i].SetActive(false);
         }
         //if the HI guess is correct then the card on the right is moved to the LeftCardst
         //now this card is to be guessed against 
         //uses "newCardActualCard" not "newCardValue" as "newCardActualCard" is the real (1 - 52) card not the corrosponding value (1 - 13)
         LeftCards[newCardActualCard].SetActive(true);
         dealingCardValue = newCardValue;

         //Turning HI and LO button back on so user can guess again
         HIButton.SetActive(true);
         LOButton.SetActive(true);
      }
      else
      {
         //if the session score is greater than the high score it becomes the high score
         if (KeepScore.score > KeepScore.highScore ){
            KeepScore.highScore = KeepScore.score;
         }
         //elapsed time stops 
         ElapsedTime.playing = false;
         //if the HI guess is incorrect then the "you're wrong" text appears for 2 seconds and the wrongGuess audio plays
         loser.SetActive(true);
         wrongGuess.Play();
         yield return new WaitForSeconds(2);

         loser.SetActive(false);
         //if the HI guess is incorrect then the shuffle button appears and the cards played is set back to 1
         ShuffleButton.SetActive(true); 

         //if the HI guess is incorrect and the last card has been played then the cardsplayed variable is reset otherwise the game carries on
         if (cardsPlayed == 52){
            cardsPlayed = 1;
            HIButton.SetActive(false);
            LOButton.SetActive(false);

         }else{
            cardsPlayed += 1;
         }  
      }
   }


   //LOGuess coroutine
   IEnumerator LOGuess()
   {
      //delays the program for 1 second (time until "You're right / wrong" text appears on screen)
      yield return new WaitForSeconds(1);

      //if the card is a joker
      if (newCardValue == 0){
         //increments the number of cards played by 1 to keep track of prgression (for termination)
         cardsPlayed += 1;
         if (cardsPlayed == 53){
            HIButton.SetActive(false);
            LOButton.SetActive(false);
            yield break;
         }

         doublePoints = true;

         //joker dissapears
         for (int i = 0; i <= 52; i++)
         {
            RightCards
      [i].SetActive(false);
         }

         //Turning HI and LO button back on so user can guess again
         HIButton.SetActive(true);
         LOButton.SetActive(true);
         yield break;
      }

      // if the walue of the new card is lower than the value of the original card then the 
      //winner text is displayed, otherwise the loser text is displayed
      else if(newCardValue < dealingCardValue)
      {
         //tells the KeepScore script that the user has won another point if joker is active then double points are on and the user gets 2 points
         if (doublePoints == true){
            KeepScore.score += 2;
         }else{
            KeepScore.score += 1;
         }

         //increments the number of cards played by 1 to keep track of prgression (for termination)
         cardsPlayed += 1;
         if (cardsPlayed == 53){
            HIButton.SetActive(false);
            LOButton.SetActive(false);
            yield break;
         }
         

         //if the LO guess is correct then the "you're right" text appears for 2 seconds and the rightGuess audio plays
         winner.SetActive(true);
         rightGuess.Play();
         yield return new WaitForSeconds(2);
         winner.SetActive(false);
         //if the LO guess is correct then the cards on the LeftCardst and right stack disapear
         for (int i = 1; i <= 52; i++)
         {
            LeftCards[i].SetActive(false);
            RightCards
      [i].SetActive(false);
         }
         //if the LO guess is correct then the card on the right is moved to the LeftCardst
         //now this card is to be guessed against 
         //uses "newCardActualCard" not "newCardValue" as "newCardActualCard" is the real (1 - 52) card not the corrosponding value (1 - 13)
         LeftCards[newCardActualCard].SetActive(true);
         dealingCardValue = newCardValue;

         //Turning HI and LO button back on so user can guess again
         HIButton.SetActive(true);
         LOButton.SetActive(true);
      }
      else
      {
         //if the session score is greater than the high score it becomes the high score
         if (KeepScore.score > KeepScore.highScore ){
            KeepScore.highScore = KeepScore.score;
         }
         //if the LO guess is incorrect then the "you're wrong" text appears for 2 seconds and the wrongGuess audio plays
         loser.SetActive(true);
         wrongGuess.Play();
         yield return new WaitForSeconds(2);

         //elapsed time stops 
         ElapsedTime.playing = false;
         loser.SetActive(false);
         //if the LO guess is incorrect then the shuffle button appears and the cards played is set back to 1
         ShuffleButton.SetActive(true);

         //if the LO guess is incorrect and the last card has been played then the cardsplayed variable is reset otherwise the game carries on
         if (cardsPlayed == 52){
            cardsPlayed = 1;
            HIButton.SetActive(false);
            LOButton.SetActive(false);
         }else{
            cardsPlayed += 1;
         } 
      }
   }

   //runs when all cards have been guessed correctly and the game is over 
   IEnumerator Champion()
   {
      HIButton.SetActive(false);
      LOButton.SetActive(false);

      //if the session score is greater than the high score it becomes the high score
      if (KeepScore.score > KeepScore.highScore ){
         KeepScore.highScore = KeepScore.score;
      }
      //elapsed time stops 
      ElapsedTime.playing = false;

      yield return new WaitForSeconds(1);
      //Champion image appears for 2 seconds and champion sound plays
      champion.SetActive(true);
      finalSound.Play();
      yield return new WaitForSeconds(4);

      champion.SetActive(false);
      //the shuffle button appears 
      ShuffleButton.SetActive(true);
   }


}