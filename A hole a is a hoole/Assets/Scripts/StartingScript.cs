using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartingScript : MonoBehaviour
{
    public GameObject StartingPanel;
    public GameObject ScorePanel;
    public GameObject GameManager;
    public TextMeshProUGUI TextNumber;
    public float _timerCountdown = 6f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        _timerCountdown -= Time.deltaTime;
        if (_timerCountdown <= 0f)
        {
            StartingPanel.SetActive(false);
            ScorePanel.SetActive(true);
            GameManager.SetActive(true);
            return;
        }
        int _text = (int)_timerCountdown;
        TextNumber.SetText(_text.ToString());
    }

}
