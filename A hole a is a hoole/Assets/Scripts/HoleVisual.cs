using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoleVisual : MonoBehaviour
{
    public string  keyPadName = "";
    public bool isSpilling = false;

    [Header("UI links")]
    public List<GameObject> damages;
    public GameObject keypadUi;
    public ParticleSystem spillEffect;
    public ParticleSystem stopSpillEffect;

    // Start is called before the first frame update
    void Start()
    {
        // A enlever
        //StartHole("A");
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("caca");
            if (isSpilling == true)
                StopSpill();
        }
        else
            Spill();
            */
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

    public void DisplayKeyPad()
    {
        keypadUi.SetActive(true);
        keypadUi.GetComponentInChildren<TextMeshPro>().text = keyPadName;
    }

    public void StopHole()
    {
        // faire apparaitre un truc de réparation à cet endroit
        Destroy(this.gameObject);
    }
}
