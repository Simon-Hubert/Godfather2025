using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // si tu veux garder le score entre les scènes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore()
    {
        score += 1;
        PlayerPrefs.SetInt("LastScore", score);
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    public void SetScore()
    {
        score = 0;
    }
}
