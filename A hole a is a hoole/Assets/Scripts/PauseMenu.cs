using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuPanel;
    public bool pause = false;
    private InputAction _inputAction;
    private Keyboard _keyboard;

    // Start is called before the first frame update
    void Start()
    {
        _keyboard = Keyboard.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (_keyboard.escapeKey.wasPressedThisFrame)
            PauseGame();

        if (pause)
        {
            Time.timeScale = 0;
            PauseMenuPanel.SetActive(true);
            GetComponent<ScoringManager>().scoreMove = false;
        }
        else
        {
            Time.timeScale = 1;
            PauseMenuPanel.SetActive(false);
            GetComponent<ScoringManager>().scoreMove = true;
        }
    }

    private void PauseGame()
    {
        pause = !pause;
    }

    public void ResumeMenu()
    {
        pause = false;
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}