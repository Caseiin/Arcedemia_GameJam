using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReaderSO", menuName = "Scriptable Objects/InputReaderSO")]
public class InputReaderSO : ScriptableObject, ArcademiaZA.IPlayer1Actions
{
    public void Enable()
    {
        ArcademiaZA inputs = new ArcademiaZA();
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
    
    }

    public void OnStart(InputAction.CallbackContext context)
    {
    
    }
}
