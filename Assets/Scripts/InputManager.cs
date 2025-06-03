using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public Controls controls = null;
    public Vector2 mousePosition;
    public Vector2 mouseScroll;
    public GameObject clickSFX;
    public event Action<Vector2> mouseClick;
    public static InputManager Instance { get; private set; }
    private void OnEnable() => controls.UI.Enable();
    private void OnDisable() => controls.UI.Disable();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        controls = new Controls();
        controls.UI.Click.performed += context => OnClick(context);
    }
    public void ClickSFX()
    {
        Instantiate(clickSFX);
    }
    void OnClick(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        //Debug.Log(context.performed);
        mousePosition = controls.UI.Point.ReadValue<Vector2>();
        mouseClick?.Invoke(mousePosition);
    }
    // Update is called once per frame
    void Update()
    {
        mousePosition = controls.UI.Point.ReadValue<Vector2>();
    }
}
