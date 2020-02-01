using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameScript : MonoBehaviour
{
    private static MiniGameScript _instance;

    public static MiniGameScript Instance { get { return _instance; } }

    public GameObject progressBar, infoBox, counterBox;

    public GameObject key1,
        key2,
        key3,
        key4,
        key5,
        key6,
        key7,
        key8,
        key9,
        key10;

    private TextMeshProUGUI _infoText, _counterText;

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

    void Start()
    {
        _infoText = infoBox.GetComponentInChildren<TextMeshProUGUI>();
        _counterText = counterBox.GetComponentInChildren<TextMeshProUGUI>();
        ResetChallengeInfos();
        gameObject.SetActive(false);
    }

    void Update()
    {

    }

    public void ResetChallengeInfos()
    {
        SetInfoText("");
        SetProgress(0);
        SetCounterText("");
        key1.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key1.SetActive(false);
        key2.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key2.SetActive(false);
        key3.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key3.SetActive(false);
        key4.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key4.SetActive(false);
        key5.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key5.SetActive(false);
        key6.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key6.SetActive(false);
        key7.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key7.SetActive(false);
        key8.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key8.SetActive(false);
        key9.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key9.SetActive(false);
        key10.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key10.SetActive(false);
    }

    public void SetInfoText(String newInfoText)
    {
        _infoText.text = newInfoText;
    }

    public void SetCounterText(String newCounterText)
    {
        _counterText.text = newCounterText;
    }

    public void SetProgress(int percentage)
    {
        progressBar.transform.localScale = new Vector3(percentage * 0.01f, 1, 1);
    }

    public void SetGameKeys(String keys)
    {
        if (keys.Length > 10)
        {
            Debug.LogError("No more than 10 keys needed");
            return;
        }

        if (keys.Length > 0)
        {
            key1.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[0].ToString();
            key1.SetActive(true);
        }
        if (keys.Length > 1)
        {
            key2.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[1].ToString();
            key2.SetActive(true);
        }
        if (keys.Length > 2)
        {
            key3.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[2].ToString();
            key3.SetActive(true);
        }
        if (keys.Length > 3)
        {
            key4.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[3].ToString();
            key4.SetActive(true);
        }
        if (keys.Length > 4)
        {
            key5.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[4].ToString();
            key5.SetActive(true);
        }
        if (keys.Length > 5)
        {
            key6.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[5].ToString();
            key6.SetActive(true);
        }
        if (keys.Length > 6)
        {
            key7.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[6].ToString();
            key7.SetActive(true);
        }
        if (keys.Length > 7)
        {
            key8.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[7].ToString();
            key8.SetActive(true);
        }
        if (keys.Length > 8)
        {
            key9.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[8].ToString();
            key9.SetActive(true);
        }
        if (keys.Length > 9)
        {
            key10.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[9].ToString();
            key10.SetActive(true);
        }
    }
}
