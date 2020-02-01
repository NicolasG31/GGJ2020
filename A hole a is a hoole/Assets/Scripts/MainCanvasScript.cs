using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCanvasScript : MonoBehaviour
{
    public Button startButton, optionButton, exitButton;
    public AudioSource audioData;

    void Start()
    {
        startButton.onClick.AddListener(OnStartButton);
        optionButton.onClick.AddListener(OnOptionButton);
        exitButton.onClick.AddListener(OnExitButton);
    }

    void OnStartButton()
    {
        audioData.Play();
        SceneManager.LoadScene("MainScene");
    }

    void OnOptionButton()
    {
        audioData.Play();
    }

    void OnExitButton()
    {
        audioData.Play();
        Application.Quit();
    }
}
