using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnAnyKeyPressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Any!");
    }

    private void OnDownButtonPressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Down!");
    }

    private void OnUpButtonPressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Up!");
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Standard.Up.started += OnUpButtonPressed;
        playerControls.Standard.Down.started += OnDownButtonPressed;
        playerControls.Standard.KeyPressed.started += OnAnyKeyPressed;
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.Standard.Up.started -= OnUpButtonPressed;
        playerControls.Standard.Down.started -= OnDownButtonPressed;
        playerControls.Standard.KeyPressed.started -= OnAnyKeyPressed;
    }
}
