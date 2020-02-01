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

    private InputAction _inputAction;

    private float gaugeNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        // A enlever
        StartHole("A");
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
        // L'eau se verse
    }

    public void StopSpill()
    {
        isSpilling = false;
        spillEffect.enableEmission = false;
        stopSpillEffect.enableEmission = true;
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
        // faire apparaitre un truc de réparation à cet endroit
        Destroy(this.gameObject);
    }
}
