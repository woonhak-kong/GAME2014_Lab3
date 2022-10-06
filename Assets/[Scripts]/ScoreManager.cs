using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scorelabel;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

  
    public int GetScore()
    {
        return score;
    }

    public void AddPoint(int points)
    {
        score += points;
        UpdateScore();
    }

    public void SetScore(int value)
    {
        score = value;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scorelabel.text = $"Score: {score}";
    }
}

