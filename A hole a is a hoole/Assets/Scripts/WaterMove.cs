using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    public GameObject waterWall;
    public float waterVolume = -13;

    // Start is called before the first frame update
    void Start()
    {
        // Vector3 tmp = new Vector3(0, waterVolume, 0);
        // waterWall.transform.position = tmp;
        ChangeWater();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeWater();
    }

    void ChangeWater()
    {
        if (waterVolume >= 2)
        {
            waterVolume = 2;
        }
        else if (waterVolume <= -12.5)
        {
            waterVolume = -12.5f;
        }
        Vector3 tmp = new Vector3(0, waterVolume, 0);
        waterWall.transform.position = tmp;
    }
}
