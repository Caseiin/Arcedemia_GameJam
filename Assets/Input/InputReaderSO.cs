using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReaderSO", menuName = "Scriptable Objects/InputReaderSO")]
public class InputReaderSO : ScriptableObject, ArcademiaZA.IPlayer1Actions
{
    public ArcademiaZA inputs;
    public Vector2 Move{get; private set;}

    public void EnableMap()
    {
        if (inputs == null)
        {
            inputs = new ArcademiaZA();
        }
        inputs.Player1.SetCallbacks(this);
        inputs.Enable();
        Debug.Log("Input Enabled");
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
        Debug.Log("Move triggered: " + context.phase);
        Move = context.ReadValue<Vector2>();
    }

    public void OnStart(InputAction.CallbackContext context)
    {
    
    }
}
