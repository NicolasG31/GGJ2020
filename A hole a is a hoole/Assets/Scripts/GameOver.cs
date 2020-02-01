using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;
    public bool EndGame = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EndGame == true)
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0;
            //GameOverPanel.SetActive(true);
        }
    }

    public void GameStop()
    {
        EndGame = true;
    }
}
