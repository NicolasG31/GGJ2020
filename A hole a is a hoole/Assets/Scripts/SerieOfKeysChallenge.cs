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
    private InputAction _inputAction;
    private float _limitTimer = 0.0f;
    private static float _timeOfLimit = 6f;
    private bool _challengeIsPlaying = false;
    private string _serieOfKeysStr = "";

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
        {
            MiniGameScript.Instance.SetProgress((int)((_limitTimer / _timeOfLimit) * 100));
            _limitTimer += Time.deltaTime;
        }

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

    public IEnumerator LaunchChallenge()
    {
        MiniGameScript.Instance.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        _serieOfKeysStr = "";
        for (int i = 0; i < _numberOfKeys; i++)
        {
            int unicode = Random.Range(97, 123);
            char character = (char)unicode;
            string key = character.ToString();
            if (i == 0 || !_serieOfKeysStr.Contains(key))
            {
                //_currentSerieOfKeys.Push(key);
                _serieOfKeysStr += key;
            }
            else
                i--;
        }
        _inputAction.ApplyBindingOverride("<Keyboard>/#(" + _serieOfKeysStr[0] + ")");
        _challengeIsPlaying = true;

        MiniGameScript.Instance.SetInfoText("Press the serie of key in the correct order !");
        MiniGameScript.Instance.SetProgress(0);
        MiniGameScript.Instance.SetGameKeys(_serieOfKeysStr);
    }

    private void HasPressedCorrectKey()
    {
        if (!_challengeIsPlaying)
            return;
        _serieOfKeysStr = _serieOfKeysStr.Substring(1);
        if (_serieOfKeysStr.Length == 0)
            ChallengeSucceed();
        else
            _inputAction.ApplyBindingOverride("<Keyboard>/#(" + _serieOfKeysStr[0] + ")");

        MiniGameScript.Instance.SetGameKeys(_serieOfKeysStr);
    }

    private void ChallengeSucceed()
    {
        MiniGameScript.Instance.SetInfoText("Challenge succeeded !");
        StartCoroutine(ResetChallenge());
        StartCoroutine(WaterMove.Instance.ReduceWater(0.075f));
    }

    private void ChallengeFailed()
    {
        MiniGameScript.Instance.SetInfoText("Challenge failed !");
        StartCoroutine(ResetChallenge());
        StartCoroutine(WaterMove.Instance.IncreaseWater(-0.025f));
    }

    private IEnumerator ResetChallenge()
    {
        _challengeIsPlaying = false;
        _limitTimer = 0.0f;
        yield return new WaitForSeconds(2f);
        MiniGameScript.Instance.ResetChallengeInfos();
        MiniGameScript.Instance.gameObject.SetActive(false);
    }
}
