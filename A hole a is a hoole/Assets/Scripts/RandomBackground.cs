using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBackground : MonoBehaviour
{
    public Sprite[] backgrounds;

    // Start is called before the first frame update
    void Start()
    {
        int num = Random.Range(0, 3);
        GetComponent<Image>().sprite = backgrounds[num];
    }
}
