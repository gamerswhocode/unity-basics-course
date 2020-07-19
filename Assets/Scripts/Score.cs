using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    private int score;

    public int ScoreInt
    {
        get { return score; }
        set 
        { 
            score += value;
            scoreText.text = "Score: " + score;
        }
    }


    public static Score Instance;

    private void Awake()
    {
        Instance = this;
        scoreText.text = "Score: 0"; 
    }

    
}
