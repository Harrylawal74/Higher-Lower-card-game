using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeepScore : MonoBehaviour
{

    public static int score = 0;
    public static int highScore = 0;


    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI highScoreText;
    void Update()
    {
        scoreText.text = "Score: " + score;

        highScoreText.text = "High score: " + highScore;
    }
}
