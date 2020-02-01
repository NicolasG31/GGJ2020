using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hole : MonoBehaviour
{
    private string _assignedKey = "";
    private InputAction _pressedKeyboard;
    private HoleVisual _holeVisual;
    private bool _isPressingKey = false;
    private float _totalHoldDuration = 0.0f;
    private float _timeOfPress = 0.0f;
    private HoleApparition _holeApparition;

    void Start()
    {
        _assignedKey = AssignKey.Instance.GetRandomKey();
        _totalHoldDuration = RepairTime.Instance.GetRepairTime();
        _holeApparition = FindObjectOfType<HoleApparition>();

        _pressedKeyboard = new InputAction("press", binding: "<Keyboard>/#(" + _assignedKey + ")",
            interactions: "hold(duration=" + _totalHoldDuration.ToString() + ")");
        _pressedKeyboard.started += _ => HasStartedToPress();
        _pressedKeyboard.canceled += _ => CancelledPress();
        _pressedKeyboard.Enable();

        _holeVisual = GetComponent<HoleVisual>();
        _holeVisual.StartHole(_assignedKey.ToUpper());
    }

    private void OnDestroy()
    {
        _pressedKeyboard.Disable();
    }

    private void Update()
    {
        if (_isPressingKey)
        {
            _timeOfPress += Time.deltaTime;
            _holeVisual.CompletionPercentage(_timeOfPress / _totalHoldDuration);
            if (_timeOfPress >= _totalHoldDuration)
                StartCoroutine(FinishedToPress());
        }
        else if (_timeOfPress > 0)
        {
            _timeOfPress -= Time.deltaTime;
            _holeVisual.CompletionPercentage(_timeOfPress / _totalHoldDuration);
        }
    }

    private void HasStartedToPress()
    {
        Debug.Log("BEGIN TO PRESS CORRECT KEY");
        _isPressingKey = true;
        _holeVisual.StopSpill();
    }

    private IEnumerator FinishedToPress()
    {
        _holeApparition.DestroyAHole(gameObject);
        _isPressingKey = false;
        Debug.Log("FINISHED TO PRESS CORRECT KEY");
        _holeVisual.StopHole();
        _pressedKeyboard.Disable();
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void CancelledPress()
    {
        _isPressingKey = false;
        _holeVisual.Spill();
        Debug.Log("CANCEL TO PRESS KEY");
    }
}
