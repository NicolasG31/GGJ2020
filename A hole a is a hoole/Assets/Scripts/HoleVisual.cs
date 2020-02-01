using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HoleVisual : MonoBehaviour
{
    public string  keyPadName = "";
    public bool isSpilling = false;

    [Header("UI links")]
    public List<GameObject> damages;
    public GameObject keypadUi;
    public ParticleSystem spillEffect;
    public ParticleSystem stopSpillEffect;
    public Image gauge;
    public GameObject duckTape;

    private InputAction _inputAction;

    private float gaugeNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        // A enlever
//        StartHole("A");
//        StopHole();
    }

    public void StartHole(string keypad)
    {
        keyPadName = keypad;
        int i = Random.Range(0, damages.Count);
        for (int a = 0; a < damages.Count; a++)
        {
            if (a == i)
                damages[a].SetActive(true);
            else
                damages[a].SetActive(false);
        }
        DisplayKeyPad();
        Spill();
    }

    public void Spill()
    {
        isSpilling = true;
        spillEffect.enableEmission = true;
        stopSpillEffect.enableEmission = false;
        gauge.GetComponent<Image>().color = Color.white;
        // L'eau se verse
    }

    public void StopSpill()
    {
        isSpilling = false;
        spillEffect.enableEmission = false;
        stopSpillEffect.enableEmission = true;
        gauge.GetComponent<Image>().color = Color.green;
        // L'eau est retenue
    }

    private void DisplayKeyPad()
    {
        keypadUi.SetActive(true);
        keypadUi.GetComponentInChildren<TextMeshPro>().text = keyPadName;
    }

    public void CompletionPercentage(float perc) // VALEUR DE 0 (JAUGE BASSE) à 1 (HAUGE HAUTE)
    {
        gauge.fillAmount = perc;
    }

    public void StopHole()
    {
        spillEffect.enableEmission = false;
        stopSpillEffect.enableEmission = false;
        gauge.gameObject.SetActive(false);
        keypadUi.SetActive(false);
        GameObject objTape = Instantiate(duckTape, damages[0].transform.position, Quaternion.Euler(0, 0, Random.RandomRange(0, 180)));
        Destroy(objTape, 5f);
    }
}
