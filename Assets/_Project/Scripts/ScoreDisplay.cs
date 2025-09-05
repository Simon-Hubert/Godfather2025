using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        if (scoreText)
        {
            scoreText.text = "Your Score : " + lastScore.ToString();
        }
    }
}
