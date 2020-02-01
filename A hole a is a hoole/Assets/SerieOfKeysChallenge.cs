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
    private static float _timeBetweenChanges = 30f;
    private Stack<string> _currentSerieOfKeys = new Stack<string>();
    private InputAction _inputAction;

    private void Start()
    {
        LaunchChallenge();
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
        _inputAction = new InputAction("press", binding: "<Keyboard>/#(" + _currentSerieOfKeys.Peek() + ")");
        _inputAction.performed += _ => HasPressedCorrectKey();
        _inputAction.Enable();
        Debug.Log("Must press " + _currentSerieOfKeys.Peek());
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
            _inputAction.ApplyBindingOverride("<Keyboard>/" + currentKey);
        }
    }

    private void ChallengeSucceed()
    {
        Debug.Log("CHALLENGE SUCCEED");
    }
}
