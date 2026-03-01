using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    Stack<CheckPointMemento> _history;
    CheckPointOriginator _originator;

    void Awake()
    {
        _history = new Stack<CheckPointMemento>();
        _originator = FindFirstObjectByType<CheckPointOriginator>();
        StoreCheckPoint();
    }


    public void StoreCheckPoint()
    {
        var savedPoint =_originator.SaveCheckPoint();
        if(_history.Contains(savedPoint)) return; 
        Debug.Log($"Checkpoint saved: location{savedPoint.CheckPoint}");
        _history.Push(savedPoint);        
    }

    public void Respawn()
    {
        CheckPointMemento Respawnpoint;
        if (_history.Count >1)
        {
            Respawnpoint = _history.Pop();
        }
        else Respawnpoint = _history.Peek();
        
        Debug.Log($"Checkpoint restored: location{Respawnpoint.CheckPoint}");
        _originator.RestoreCheckPoint(Respawnpoint);
    }


}

