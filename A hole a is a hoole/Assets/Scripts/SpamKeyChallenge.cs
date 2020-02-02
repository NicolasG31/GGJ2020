using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpamKeyChallenge : MonoBehaviour
{
    private static SpamKeyChallenge _instance;

    public static SpamKeyChallenge Instance
    {
        get { return _instance; }
    }

    public AudioSource loseSound, winSound;

    private InputAction _inputAction;
    private int _nbrToSpam = 6;
    private float _timer = 0.0f;
    private static float _timeBetweenChanges = 40f;
    private int _countOfSpam = 0;
    private float _limitTimer = 0.0f;
    private static float _timeOfLimit = 6f;
    private bool _challengeIsPlaying = false;
    private string _keyToSpam = "";

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
            if (_nbrToSpam > 16)
                _nbrToSpam = 16;
            _timer = 0f;
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
        char character = (char) unicode;
        _keyToSpam = character.ToString();

        _inputAction.ApplyBindingOverride("<Keyboard>/#(" + _keyToSpam + ")");
        _challengeIsPlaying = true;
        MiniGameScript.Instance.SetInfoText("Press the " + _keyToSpam + " key " + _nbrToSpam + " times !");
        MiniGameScript.Instance.SetProgress(0);
        MiniGameScript.Instance.SetGameKeys(_keyToSpam);
        MiniGameScript.Instance.SetCounterText(_nbrToSpam.ToString());
    }

    private void HasPressedCorrectKey()
    {
        if (!_challengeIsPlaying)
            return;
        _countOfSpam++;
        MiniGameScript.Instance.SetCounterText((_nbrToSpam - _countOfSpam).ToString());
        MiniGameScript.Instance.SetInfoText("Press the " + _keyToSpam + " key " +
                                            (_nbrToSpam - _countOfSpam).ToString() + " times !");
        if (_countOfSpam >= _nbrToSpam)
            ChallengeSucceed();
    }

    private void ChallengeSucceed()
    {
        winSound.Play();
        MiniGameScript.Instance.SetInfoText("Challenge succeeded !");
        StartCoroutine(ResetChallenge());
        StartCoroutine(WaterMove.Instance.ReduceWater(0.075f));
        Debug.Log("CHALLENGE SUCCEED");
    }

    private void ChallengeFailed()
    {
        loseSound.Play();
        MiniGameScript.Instance.SetInfoText("Challenge failed !");
        StartCoroutine(ResetChallenge());
        StartCoroutine(WaterMove.Instance.IncreaseWater(-0.025f));
        Debug.Log("CHALLENGE FAILED");
    }

    private IEnumerator ResetChallenge()
    {
        _keyToSpam = "";
        _countOfSpam = 0;
        _challengeIsPlaying = false;
        _limitTimer = 0.0f;
        yield return new WaitForSeconds(2f);
        MiniGameScript.Instance.ResetChallengeInfos();
        MiniGameScript.Instance.gameObject.SetActive(false);
    }
}
