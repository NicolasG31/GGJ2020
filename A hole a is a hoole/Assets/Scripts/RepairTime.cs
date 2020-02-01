using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTime : MonoBehaviour
{
    private static RepairTime _instance;

    public static RepairTime Instance { get { return _instance; } }

    private float _timer = 0.0f;
    private static float _timeBetweenChanges = 60f;
    private float _timeToRepair = 5.0f;

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

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeBetweenChanges && _timeToRepair > 0.2f)
        {
            _timeToRepair -= 0.3f;
        }
    }

    public float GetRepairTime()
    {
        return (_timeToRepair);
    }
}
