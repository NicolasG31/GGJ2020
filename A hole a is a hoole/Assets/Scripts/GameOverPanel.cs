using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public TextMeshProUGUI TextScoreNumber;
    public GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        int _score = (int)GameManager.GetComponent<ScoringManager>().Score;
        TextScoreNumber.SetText(_score.ToString());
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
