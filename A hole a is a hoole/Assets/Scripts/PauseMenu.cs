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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard.escapeKey.isPressed)
            PauseGame();

        if (pause)
        {
            Time.timeScale = 0;
            PauseMenuPanel.SetActive(true);
            GetComponent<WaterMove>().waterMoving = false;
        }
        else
        {
            Time.timeScale = 1;
            PauseMenuPanel.SetActive(false);
            GetComponent<WaterMove>().waterMoving = true;
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