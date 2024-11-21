using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Diagnostics;


public class ElapsedTime : MonoBehaviour
{
    public static int minutes = 0;
    public static int seconds = 0;
    public TextMeshProUGUI timeText;
    private float elapsedTime = 0f;

    public static bool playing;
   
    //elapsed time function which counts the mins and secs that have elapsed in your current session (from deal)
    void Update()
    {
        //the time only shows if playing is true (after the deal button has been pressed and before the shuffle button has been pressed)
        if (playing == true){
            elapsedTime += Time.deltaTime;
            //DIV returns the (quotient of the divison)
            minutes = Mathf.FloorToInt(elapsedTime / 60);

            //modulo divison (returns the remainder of the division)
            seconds = Mathf.FloorToInt(elapsedTime % 60);

            timeText.text = "Elapsed Time: " + minutes +" : "+ seconds;
        }
        else{
            //displays the total time spent playing in that session
            timeText.text = "Elapsed Time: " + minutes +" : "+ seconds;

            //resets elapsedTime for the next session
            elapsedTime = 0;
        }
        
    }
}
