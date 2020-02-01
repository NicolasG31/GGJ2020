using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SerieOfKeysChallenge : MonoBehaviour
{
    private static SerieOfKeysChallenge _instance;

    public static SerieOfKeysChallenge Instance { get { return _instance; } }

    private int _numberOfKeys = 3;
    private float _timer = 0.0f;
    private static float _timeBetweenChanges = 60f;
    private Stack<string> _currentSerieOfKeys = new Stack<string>();
    private InputAction _inputAction;
    private float _limitTimer = 0.0f;
    private static float _timeOfLimit = 6f;
    private bool _challengeIsPlaying = false;

    private void Start()
    {
        _inputAction = new InputAction("SerieOfKeysChallenge", binding: "<Keyboard>/#()");
        _inputAction.performed += _ => HasPressedCorrectKey();
        _inputAction.Enable();
    }

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

    private void OnDestroy()
    {
        _inputAction.Disable();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeBetweenChanges)
        {
            _numberOfKeys++;
            _timer = 0.0f;
        }

        if (_challengeIsPlaying)
            _limitTimer += Time.deltaTime;

        if (_limitTimer >= _timeOfLimit)
        {
            ChallengeFailed();
            _limitTimer = 0.0f;
        }
    }

    private string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        System.Array.Reverse(charArray);
        return new string(charArray);
    }

    private void LaunchChallenge()
    {
        string serieOfKeysStr = "";
        for (int i = 0; i < _numberOfKeys; i++)
        {
            int unicode = Random.Range(97, 123);
            char character = (char)unicode;
            string key = character.ToString();
            if (i == 0 || key != _currentSerieOfKeys.Peek())
            {
                _currentSerieOfKeys.Push(key);
                serieOfKeysStr += key;
            }
            else
                i--;
        }
        serieOfKeysStr = Reverse(serieOfKeysStr);
        Debug.Log("Challenge Serie of Keys: " + serieOfKeysStr);
        _inputAction.ApplyBindingOverride("<Keyboard>/#(" + _currentSerieOfKeys.Peek() + ")");
        Debug.Log("Must press " + _currentSerieOfKeys.Peek());
        _challengeIsPlaying = true;
    }

    private void HasPressedCorrectKey()
    {
        string currentKey = _currentSerieOfKeys.Peek();
        _currentSerieOfKeys.Pop();
        Debug.Log("Correctly pressed " + currentKey);
        if (_currentSerieOfKeys.Count == 0)
            ChallengeSucceed();
        else
        {
            currentKey = _currentSerieOfKeys.Peek();
            Debug.Log("Must press " + currentKey);
            _inputAction.ApplyBindingOverride("<Keyboard>/#(" + currentKey + ")");
        }
    }

    private void ChallengeSucceed()
    {
        ResetChallenge();
        Debug.Log("CHALLENGE SUCCEED");
        LaunchChallenge();
    }

    private void ChallengeFailed()
    {
        ResetChallenge();
        Debug.Log("CHALLENGE FAILED");
    }

    private void ResetChallenge()
    {
        _challengeIsPlaying = false;
        _limitTimer = 0.0f;
    }
}
