using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hole : MonoBehaviour
{
    private string _assignedKey = "";

    void Start()
    {
        _assignedKey = AssignKey.Instance.GetRandomKey();

        InputAction pressedKeyboard = new InputAction();
    }

    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
