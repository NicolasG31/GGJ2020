using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeManager : MonoBehaviour
{
    private static ChallengeManager _instance;

    public static ChallengeManager Instance { get { return _instance; } }

    private float _timer = 0.0f;
    private int _timeBetweenChallenge = 999;
    private int _currentChallengeIndex = 0;
    private static int _qntOfchallenge = 3;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        _timeBetweenChallenge = Random.Range(20, 60);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeBetweenChallenge)
        {
            int newChallengeIndex = Random.Range(0, _qntOfchallenge);
            while (newChallengeIndex != _currentChallengeIndex)
                newChallengeIndex = Random.Range(0, _qntOfchallenge);
            _currentChallengeIndex = newChallengeIndex;
            LaunchChallenge(_currentChallengeIndex);
            _timeBetweenChallenge = Random.Range(40, 90);
            _timer = 0.0f;
        }
    }

    private void LaunchChallenge(int challIndx)
    {
        switch (challIndx)
        {
            case 0:
                Debug.Log("Challenge 0");
                StartCoroutine(SerieOfKeysChallenge.Instance.LaunchChallenge());
                break;
            case 1:
                Debug.Log("Challenge 1");
                StartCoroutine(SpamKeyChallenge.Instance.LaunchChallenge());
                break;
            case 2:
                Debug.Log("Challenge 2");
                StartCoroutine(AlternateKeysChallenge.Instance.LaunchChallenge());
                break;
        }
    }
}
