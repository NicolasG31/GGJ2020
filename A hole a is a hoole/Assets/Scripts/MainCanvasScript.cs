using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

public class MainCanvasScript : MonoBehaviour
{
    public Button startButton, optionButton, exitButton;
    public AudioSource audioData;
    public GameObject fishPrefab;

    public Sprite[] sprites;

    private float _timer = 0.0f;
    private List<GameObject> _fishList;

    void Start()
    {
        startButton.onClick.AddListener(OnStartButton);
        optionButton.onClick.AddListener(OnOptionButton);
        exitButton.onClick.AddListener(OnExitButton);

        _fishList = new List<GameObject>();

        GameObject fish = Instantiate(fishPrefab, new Vector3(0, 0, 0), Quaternion.identity,
            GameObject.FindGameObjectWithTag("Canvas").transform);

        _fishList.Add(fish);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 2.0f)
        {
            Random random = new Random();

            GameObject fish = Instantiate(fishPrefab, new Vector3(random.Next(1920), random.Next(1080), 0), Quaternion.identity,
                GameObject.FindGameObjectWithTag("Canvas").transform);
            fish.GetComponent<Image>().sprite = sprites[random.Next(4)];
            _fishList.Add(fish);
            _timer = _timer - 2.0f;
        }

        foreach (GameObject obj in _fishList)
        {
            obj.transform.Translate(1, 2, 0);
            obj.transform.Rotate(1, 1, 0);
        }
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
