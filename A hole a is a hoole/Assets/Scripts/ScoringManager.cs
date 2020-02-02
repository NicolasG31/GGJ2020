using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public float Score = 0;
    public float valueScoreTime = 1;
    public bool scoreMove = true;

    public float apparitionTime = 1f;
    private float _timerApparition = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreMove)
        {
            _timerApparition += Time.deltaTime;
            if (_timerApparition >= apparitionTime)
            {
                IncreaseScore(valueScoreTime);
                _timerApparition = 0f;
            }
        }
            
    }

    public void IncreaseScore(float value = 1f)
    {
        Score += value;
        int _score = ((int)Score);
        ScoreText.SetText(_score.ToString());
    }
}
