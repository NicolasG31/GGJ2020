using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCanvasScript : MonoBehaviour
{
    public Button startButton, optionButton, exitButton;
    public AudioSource audioData;
    public GameObject fishPrefab;
    public GameObject fishFix;

    private GameObject fish, fish2;

    void Start()
    {
        startButton.onClick.AddListener(OnStartButton);
        optionButton.onClick.AddListener(OnOptionButton);
        exitButton.onClick.AddListener(OnExitButton);

        fish = Instantiate(fishPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        fish2 = Instantiate(fishPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void Update()
    {
        fish.transform.Translate(1, 1, 0);
        fish2.transform.Translate(1, 1, 1);
        fishFix.transform.Translate(1, 1, 0);
        fishFix.transform.Rotate(1, 1, 0);
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
