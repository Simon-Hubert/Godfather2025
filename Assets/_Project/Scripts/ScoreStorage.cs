using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStorage : MonoBehaviour
{
    public void Score(int nouveauScore)
    {
        if (nouveauScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", nouveauScore);
        }
        PlayerPrefs.SetInt("LastScore", nouveauScore);
        PlayerPrefs.Save();
    }
}
