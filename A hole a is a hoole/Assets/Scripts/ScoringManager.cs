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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreMove)
            IncreaseScore(valueScoreTime);
    }

    public void IncreaseScore(float value = 0)
    {
        Score += 1 + value;
        int _score = ((int)Score / 1000);
        ScoreText.SetText(_score.ToString());
    }
}
