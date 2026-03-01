using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReaderSO", menuName = "Scriptable Objects/InputReaderSO")]
public class InputReaderSO : ScriptableObject, ArcademiaZA.IPlayer1Actions
{
    public ArcademiaZA inputs;
    public Vector2 Move{get; private set;}

    // Events
    public static event Action OnSliderPressed;

    public static event Action<float> OnChargedSlide;
    public static event Action OnSliderReleased;

    public void EnableMap()
    {
        if (inputs == null)
        {
            inputs = new ArcademiaZA();
        }
        inputs.Player1.SetCallbacks(this);
        inputs.Enable();
    }

    public void DisableMap()
    {
        if (inputs != null)
        {
            inputs.Player1.SetCallbacks(null);
            inputs.Disable();
        }
    }


    public void OnA(InputAction.CallbackContext context)
    {
    }

    public void OnB(InputAction.CallbackContext context)
    {
    
    }

    public void OnC(InputAction.CallbackContext context)
    {
    
    }

    public void OnD(InputAction.CallbackContext context)
    {
    
    }

    public void OnE(InputAction.CallbackContext context)
    {
    
    }

    public void OnExit(InputAction.CallbackContext context)
    {
    
    }

    public void OnF(InputAction.CallbackContext context)
    {
    
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();

        if (context.started)
        {
        }

        if (context.canceled)
        {
            float holdDuration = (float)context.duration;
            // Debug.Log("Hold Duration: " + holdDuration);
            OnChargedSlide?.Invoke(holdDuration);

        }
    }

    public void OnStart(InputAction.CallbackContext context)
    {
    
    }
}
