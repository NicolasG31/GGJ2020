using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hole : MonoBehaviour
{
    private string _assignedKey = "";
    private InputAction _pressedKeyboard;

    void Start()
    {
        _assignedKey = AssignKey.Instance.GetRandomKey();

        Debug.Log("KEY TO PRESS: " + _assignedKey);
        _pressedKeyboard = new InputAction("press", binding: "<Keyboard>/" + _assignedKey,
            interactions: "hold(duration=" + RepairTime.Instance.GetRepairTime().ToString() + ")");
        _pressedKeyboard.started += _ => HasStartedToPress();
        _pressedKeyboard.performed += _ => FinishedToPress();
        _pressedKeyboard.canceled += _ => CancelledPress();
        _pressedKeyboard.Enable();
    }

    private void OnDestroy()
    {
        _pressedKeyboard.Disable();
    }

    private void HasStartedToPress()
    {
        Debug.Log("BEGIN TO PRESS CORRECT KEY");
    }

    private void FinishedToPress()
    {
        Debug.Log("FINISHED TO PRESS CORRECT KEY");
    }

    private void CancelledPress()
    {
        Debug.Log("CANCEL TO PRESS KEY");
    }
}
