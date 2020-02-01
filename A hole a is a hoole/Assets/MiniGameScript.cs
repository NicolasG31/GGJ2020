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

    public GameObject progressBar, infoBox;

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

    private TextMeshProUGUI _infoText;

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
        SetGameKeys("123456789");
        SetInfoText("this is an infotext");
    }

    void Update()
    {

    }

    public void ResetChallengeInfos()
    {
        SetInfoText("");
        SetProgress(0);
        key1.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key2.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key3.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key4.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key5.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key6.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key7.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key8.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key9.GetComponentInChildren<TextMeshProUGUI>().text = "";
        key10.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }

    public void SetInfoText(String newInfoText)
    {
        _infoText.text = newInfoText;
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
            key1.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[0].ToString();
        if (keys.Length > 1)
            key2.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[1].ToString();
        if (keys.Length > 2)
            key3.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[2].ToString();
        if (keys.Length > 3)
            key4.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[3].ToString();
        if (keys.Length > 4)
            key5.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[4].ToString();
        if (keys.Length > 5)
            key6.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[5].ToString();
        if (keys.Length > 6)
            key7.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[6].ToString();
        if (keys.Length > 7)
            key8.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[7].ToString();
        if (keys.Length > 8)
            key9.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[8].ToString();
        if (keys.Length > 9)
            key10.GetComponentInChildren<TextMeshProUGUI>().text = (keys.ToCharArray())[9].ToString();
    }
}
