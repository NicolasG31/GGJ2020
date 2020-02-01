using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTime : MonoBehaviour
{
    private static RepairTime _instance;

    public static RepairTime Instance { get { return _instance; } }

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

    public float GetRepairTime()
    {
        float time = 1.0f;

        return (time);
    }
}
