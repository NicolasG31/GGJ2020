﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AlternateKeysChallenge : MonoBehaviour
{
    private static AlternateKeysChallenge _instance;

    public static AlternateKeysChallenge Instance { get { return _instance; } }
    public AudioSource loseSound, winSound;

    private InputAction _inputAction;
    private float _limitTimer = 0.0f;
    private static float _timeOfLimit = 6f;
    private float _timer = 0.0f;
    private static float _timeBetweenChanges = 40f;
    private int _goalOfRepetition = 4;
    private bool _challengeIsPlaying = false;
    private string[] _keysToAlternate;
    private int _actualIndex = 0;
    private int _currentNbrOfRepetition = 0;

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

    // Start is called before the first frame update
    void Start()
    {
        _keysToAlternate = new string[2];
        _inputAction = new InputAction("SerieOfKeysChallenge", binding: "<Keyboard>/#()");
        _inputAction.performed += _ => HasPressedCorrectKey();
        _inputAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeBetweenChanges)
        {
            if (_goalOfRepetition < 20)
                _goalOfRepetition += 2;
            _timer = 0f;
        }

        if (_challengeIsPlaying)
        {
            _limitTimer += Time.deltaTime;
            MiniGameScript.Instance.SetProgress((int)((_limitTimer / _timeOfLimit) * 100));
        }

        if (_limitTimer >= _timeOfLimit)
        {
            ChallengeFailed();
            _limitTimer = 0f;
        }
    }

    public IEnumerator LaunchChallenge()
    {
        MiniGameScript.Instance.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        int unicode = Random.Range(97, 123);
        char character = (char)unicode;
        string key = character.ToString();

        _keysToAlternate[0] = key;

        int secondUnicode = Random.Range(97, 123);
        while (secondUnicode == unicode)
            secondUnicode = Random.Range(97, 123);
        character = (char)secondUnicode;
        key = character.ToString();

        _keysToAlternate[1] = key;

        Debug.Log("Challenge Keys to Alternate: " + _keysToAlternate[0] + " / " + _keysToAlternate[1]);
        _inputAction.ApplyBindingOverride("<Keyboard>/#(" + _keysToAlternate[0] + ")");
        _challengeIsPlaying = true;

        MiniGameScript.Instance.SetInfoText("Alternate between both keys " + _goalOfRepetition + " times !");
        MiniGameScript.Instance.SetProgress(0);
        MiniGameScript.Instance.SetGameKeys(_keysToAlternate[0] + _keysToAlternate[1]);
        MiniGameScript.Instance.SetCounterText(_goalOfRepetition.ToString());
    }

    private void HasPressedCorrectKey()
    {
        if (!_challengeIsPlaying)
            return;
        if (_actualIndex == 0)
            _actualIndex = 1;
        else
        {
            _currentNbrOfRepetition++;
            _actualIndex = 0;
            MiniGameScript.Instance.SetCounterText((_goalOfRepetition - _currentNbrOfRepetition).ToString());
            MiniGameScript.Instance.SetInfoText("Alternate between both keys " + (_goalOfRepetition - _currentNbrOfRepetition).ToString() + " times !");
        }

        if (_currentNbrOfRepetition >= _goalOfRepetition)
            ChallengeSucceed();
        else
            _inputAction.ApplyBindingOverride("<Keyboard>/#(" + _keysToAlternate[_actualIndex] + ")");
    }

    private void ChallengeSucceed()
    {
        winSound.Play();
        MiniGameScript.Instance.SetInfoText("Challenge succeeded !");
        StartCoroutine(ResetChallenge());
        StartCoroutine(WaterMove.Instance.ReduceWater(0.075f));
    }

    private void ChallengeFailed()
    {
        loseSound.Play();
        MiniGameScript.Instance.SetInfoText("Challenge failed !");
        StartCoroutine(ResetChallenge());
        StartCoroutine(WaterMove.Instance.IncreaseWater(-0.025f));
    }

    private IEnumerator ResetChallenge()
    {
        _challengeIsPlaying = false;
        _limitTimer = 0.0f;
        _actualIndex = 0;
        _currentNbrOfRepetition = 0;
        yield return new WaitForSeconds(2f);
        MiniGameScript.Instance.ResetChallengeInfos();
        MiniGameScript.Instance.gameObject.SetActive(false);
    }
}
