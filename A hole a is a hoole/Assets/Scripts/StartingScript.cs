using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartingScript : MonoBehaviour
{
    public GameObject StartingPanel;
    public TextMeshProUGUI TextNumber;
    private float _timerCountdown = 6f;
    private float countDown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        _timerCountdown -= Time.deltaTime;
        Debug.Log(_timerCountdown);
        if (_timerCountdown <= countDown)
        {
            StartingPanel.SetActive(false);
            Time.timeScale = 1;
            return;
        }
        int _text = (int)_timerCountdown;
        TextNumber.SetText(_text.ToString());
    }

}
