using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public float Score = 0;
    public float valueScoreTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseScore(valueScoreTime);
    }

    public void IncreaseScore(float value = 0)
    {
        Score += (value - (Time.deltaTime / 10000)) / 100;
        int _score = (int)Score;
        ScoreText.SetText(_score.ToString());
    }
}
