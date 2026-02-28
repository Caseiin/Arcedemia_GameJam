using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReaderSO", menuName = "Scriptable Objects/InputReaderSO")]
public class InputReaderSO : ScriptableObject, ArcademiaZA.IPlayer1Actions
{
    ArcademiaZA inputs;
    public Vector2 Move{get; private set;} 

    public void Enable()
    {
        inputs = new ArcademiaZA();
        inputs.Enable();
        inputs.Player1.SetCallbacks(this);
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
    }

    public void OnStart(InputAction.CallbackContext context)
    {
    
    }
}
