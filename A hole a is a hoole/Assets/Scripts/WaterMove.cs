using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    private static WaterMove _instance;

    public static WaterMove Instance { get { return _instance; } }

    public GameObject waterWall;
    public bool waterMoving = false;
    public float waterSpeed = 0.0005f;
    private float waterSpeedMin = 0.0005f;
    private float waterSpeedMax = 0.002f;
    private float screenSizeMax = -2.40f;
    private float screenSizeMin = -12.5f;
    private int holeCounter = 0;

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

    // Start is called before the first frame update
    void Start()
    {
        waterSpeed = 0.0005f;
        Vector3 tmp = new Vector3(0, -12.5f, 0);
        waterWall.transform.position = tmp;
        screenSizeMin = waterWall.transform.position.y;
        waterMoving = false;
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

    public IEnumerator ReduceWater(float vol)
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            reduceWaterVolume(vol);
            yield return new WaitForSeconds(.1f);
        }
    }

    public IEnumerator IncreaseWater(float vol)
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            reduceWaterVolume(vol);
            yield return new WaitForSeconds(.1f);
        }
    }

    public void ModifyHoleCounter(int modifier)
    {
        int nbrOfHole = GameObject.FindGameObjectsWithTag("KeyPad").Length;
        holeCounter += modifier;
        if (holeCounter == nbrOfHole)
            waterMoving = false;
        else
            waterMoving = true;
    }
}
