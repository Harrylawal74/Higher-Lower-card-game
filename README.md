------------Rules-----------------
1) HI LO card game using a complete 52 deck plus one joker
2) Ace counts as 1 through to king valued at 13 joker has no value
3) If the same value card is chosen on a HI pick then it's a winner. e.g. 4 of hearts is displayed and you select HI and then 4 of spades is displayed = win
4) Cannot deal a joker 
5) Joker gives a x2 bonus from when it is found
4) If the same value card is chosen on a LO pick then it's a loser. e.g. 8 of diamonds is displayed and you select LO and then 8 of clubs is displayed = lose
----------------------------------


-------------------Documentation---------------------
On game load the IntroScreen script runs which plays the background and text animation then sets both to inactive 
Music plays on loop as set in unity
Game start screen includes joker button Deal button and high score counter
If the joker is pressed then one joker is added to the deck of draw cards (a joker cannot be drawn as the first card). If the joker button is not pressed then it is not included in the cards that can be drawn
The joker gives x2 points for each correct answer
Once deal button is pressed a random card is drawn from a standard 52 card deck (not a joker). High and Low buttons appear as well as current score and elapsed time
On Hi or Lo button press a new card is drawn from the deck (all cards excluding cards already drawn plus the joker if selected beforehand) the current card (left) is compared to the card on the right and if your guess is correct "You're right" appears and if your guess is wrong "You're wrong appears" 
If your guess is correct then your score increments by 1 and the HI LO buttons reappear 
If your guess is incorrect elapsed time stops and if your high score is less than your current score then your high score is replaced with your current score and current score is set to 0, otherwise your current score is set to 0.
If guess is incorrect then the shuffle button appears. When pressed the shuffle button reactivates all used cards so the full deck can be used again
To keep track of how many cards have been used we look at the cardsPlayed variable defined in the ComparingCardValues script (this is used for terminating the program)
cardsPlayed has a default value of 1 as the first card must be considered. It increments each time we take a guess (jokers do not count as cards played)
if cards played reaches 52 then the player must have won and the champion image appears with the champion sound. The game resets and the shuffle button appears
----------------------------------------------------




-------------------Challenges-----------------------
1)
Creating a way to filter out cards that have already been used. To solve this I implemented the usedCards array in the UsedCards script. usedCards is an array of length 53 which the Deal, HI and LO button scripts interact with. Each time a card is drawn using these buttons the value is compared to the values in the usedCards array. If the value in the array is on then it cannot be used. If the value is not on then it can be used
To represent on/off: (card 34 is on therefore usedCards[34] has the value of 34) this works because usedCards[0] is the joker.
I think this method could be made more efficient seeing as a while loop is implemented in the Deal, HI and LO button scripts to find a card that has not been used. This recursive method is very inefficient but simple to implement and the array is small so not to costing

2)
using TextMeshPro to change the text on the page for score. This was a small problem but as I am still quite new to c# it took a second. I looked at w3schools and needed to use the TMPro name space and different syntax to the Text game object

3)
Trouble creating the timer function. Initially tried to use a count variable with += 1 for each frame but the frame rate is > 1 so that didn't work, played around with a few namespaces but ultimately settled on the built in UnityEngine Time() function. Time.deltaTime is independent of the frame rate so gives an accurate measure of elapsed time

4)
Termination function. Initially I used the score as a termination trigger but because the joker function rewards more points I couldn't use the points as a termination trigger. To fix this I made a variable that increments when a hi or lo button is pressed, this did not work because it meant if you picked the wrong card on the final play you still won
finally I implemented the cardsPlayed variable in the ComparingCardValues script which is hard coded to 1 (deal card) and only increments when you win a play.
----------------------------------------------------
