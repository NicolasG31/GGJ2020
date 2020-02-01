using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    public GameObject waterWall;
    public bool waterMoving = false;
    public float waterSpeed = 0.0005f;
    private float waterSpeedMin = 0.0005f;
    private float waterSpeedMax = 0.002f;
    private float screenSizeMax = -2.40f;
    private float screenSizeMin = -12.5f;

    // Start is called before the first frame update
    void Start()
    {
        waterSpeed = 0.0005f;
        Vector3 tmp = new Vector3(0, -12.5f, 0);
        waterWall.transform.position = tmp;
        screenSizeMin = waterWall.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (waterMoving)
            ChangeWater();
    }

    void ChangeWater()
    {
        float y = waterWall.transform.position.y + waterSpeed;
        if (y > screenSizeMax)
        {
            y = screenSizeMax;
            GetComponent<GameOver>().GameStop();
        }
        else if (y < screenSizeMin)
            y = screenSizeMin;
        
        Vector3 tmp = new Vector3(0, y, 0);
        waterWall.transform.position = tmp;
    }

    public void IncreaseWaterSpeed()
    {
        waterSpeed += 0.0001f;
        if (waterSpeed > waterSpeedMax)
            waterSpeed = waterSpeedMax;
    }

    public void ReduceWaterSpeed()
    {
        waterSpeed -= 0.0001f;
        if (waterSpeed < waterSpeedMin)
            waterSpeed = waterSpeedMin;
    }

    public void StartingReduceWater()
    {
        StartCoroutine("ReduceWater");
    }

    public void StartingIncreaseWater()
    {
        StartCoroutine("IncreaseWater");
    }

    private void reduceWaterVolume(float value)
    {
        Vector3 tmp = new Vector3(0, waterWall.transform.position.y - value, 0);
        waterWall.transform.position = tmp;
    }

    IEnumerator ReduceWater()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            reduceWaterVolume(0.075f);
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator IncreaseWater()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            reduceWaterVolume(-0.025f);
            yield return new WaitForSeconds(.1f);
        }
    }

}
