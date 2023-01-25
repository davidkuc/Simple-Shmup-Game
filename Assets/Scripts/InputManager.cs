using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public event Action ShootButtonPressed;
    public event Action UpButtonPressed;
    public event Action DownButtonPressed; 
    public event Action AnyButtonPressed;

    PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Standard.Shoot.started += OnShootButtonPressed;
        playerControls.Standard.Up.started += OnUpButtonPressed;
        playerControls.Standard.Down.started += OnDownButtonPressed;
        playerControls.Standard.KeyPressed.started += OnAnyKeyPressed;
    }


    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.Standard.Shoot.started -= OnShootButtonPressed;
        playerControls.Standard.Up.started -= OnUpButtonPressed;
        playerControls.Standard.Down.started -= OnDownButtonPressed;
        playerControls.Standard.KeyPressed.started -= OnAnyKeyPressed;
    }
    private void OnShootButtonPressed(InputAction.CallbackContext obj)
    {
        //Debug.Log("Shoot!");
        ShootButtonPressed?.Invoke();
    }

    private void OnAnyKeyPressed(InputAction.CallbackContext obj)
    {
       //Debug.Log("Any!");
        AnyButtonPressed?.Invoke();
    }

    private void OnDownButtonPressed(InputAction.CallbackContext obj)
    {
       // Debug.Log("Down!");
        DownButtonPressed?.Invoke();
    }

    private void OnUpButtonPressed(InputAction.CallbackContext obj)
    {
        //Debug.Log("Up!");
        UpButtonPressed?.Invoke();
    }
}
