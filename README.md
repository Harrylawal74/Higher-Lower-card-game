HI LO card game using a complete 52 deck plus jokers 
Ace counts as 1 through to king valued at 13
If the same value card is chosen on a HI pick then it's a winner. e.g. 4 of hearts is displayed and you select HI and then 4 of spades is displayed = win
If the same value card is chosen on a LO pick then it's a loser. e.g. 8 of diamonds is displayed and you select LO and then 8 of clubs is displayed = lose

in order to remove used cards from the deck I had to use...

cannot deal a joker 
can get a joker on a hi or lo guess
joker gives a x2 bonus 

challenges
creating a way to filter out cards that have already been used 
using textmeshproui to change the text on the page for score. looked at w3schools and needed to use a new name space and different syntex to text 
cannot delay the program while the shuffle sound effect plays
trouble creating the timer function initially tried to use a count variable with += 1 for each frame but the frame rate is > 1 so that didnt work, played around with a few namespaces but ultimately settled on the build in UnityEngine Time() function. Time.deltaTime is independent of the frame rate so gives an accurate measure of elapsed time 
use of recursion to check for used cards is inefficient 
termination: becuase the joker function rewards more points I couldnt use the points as a termination trigger to fix this i made a varible that incruments when a hi or lo button is pressed, this did not work beacause it meant if you picked the wrong card on the final play you still won
so instead i impletement the same idea but in the comparison functions in ComparingCardValues. this way if the 52 /53 cards have been played and the hand is wrong then cardsplayed value is reset to 1 before the champion subroutine can be triggered.
