using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;
    public AudioSource loseSound;
    public bool EndGame = false, playSound = false;

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
            GameOverPanel.SetActive(true);
            if (!playSound)
            {
                loseSound.Play();
                GetComponent<ScoringManager>().scoreMove = !GetComponent<ScoringManager>().scoreMove;
                GetComponent<WaterMove>().waterMoving = !GetComponent<WaterMove>().waterMoving;
                playSound = true;
            }
        }
    }

    public void GameStop()
    {
        EndGame = true;
    }
}
