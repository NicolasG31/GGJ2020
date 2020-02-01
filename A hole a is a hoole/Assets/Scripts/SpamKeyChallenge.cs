using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpamKeyChallenge : MonoBehaviour
{
    private static SpamKeyChallenge _instance;

    public static SpamKeyChallenge Instance { get { return _instance; } }

    private InputAction _inputAction;
    private int _nbrToSpam = 6;
    private float _timer = 0.0f;
    private static float _timeBetweenChanges = 60f;
    private int _countOfSpam = 0;
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
            _nbrToSpam += 2;
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

    public IEnumerator LaunchChallenge()
    {
        MiniGameScript.Instance.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        int unicode = Random.Range(97, 123);
        char character = (char)unicode;
        string key = character.ToString();

        _inputAction.ApplyBindingOverride("<Keyboard>/#(" + key + ")");
        _challengeIsPlaying = true;
        MiniGameScript.Instance.SetInfoText("Press the " + key + " key " + _nbrToSpam + " times !");
        MiniGameScript.Instance.SetProgress(0);
        MiniGameScript.Instance.SetGameKeys(key);
        MiniGameScript.Instance.SetCounterText(_nbrToSpam.ToString());
    }

    private void HasPressedCorrectKey()
    {
        MiniGameScript.Instance.SetCounterText((_nbrToSpam - _countOfSpam).ToString());
        _countOfSpam++;
        if (_countOfSpam >= _nbrToSpam)
            ChallengeSucceed();
    }

    private void ChallengeSucceed()
    {
        ResetChallenge();
        StartCoroutine(WaterMove.Instance.ReduceWater(0.075f));
        Debug.Log("CHALLENGE SUCCEED");
    }

    private void ChallengeFailed()
    {
        ResetChallenge();
        StartCoroutine(WaterMove.Instance.IncreaseWater(-0.025f));
        Debug.Log("CHALLENGE FAILED");
    }

    private void ResetChallenge()
    {
        _countOfSpam = 0;
        _challengeIsPlaying = false;
        _limitTimer = 0.0f;
        MiniGameScript.Instance.ResetChallengeInfos();
        MiniGameScript.Instance.gameObject.SetActive(false);
    }
}
