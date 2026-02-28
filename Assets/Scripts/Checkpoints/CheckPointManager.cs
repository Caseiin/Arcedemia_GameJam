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
    }

    void OnEnable()
    {
        CheckPointMark.onCheckPointEnter += StoreCheckPoint;
    }

    void OnDisable()
    {
        CheckPointMark.onCheckPointEnter -= StoreCheckPoint;
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
        var Respawnpoint = _history.Pop();
        Debug.Log($"Checkpoint restored: location{Respawnpoint.CheckPoint}");
        _originator.RestoreCheckPoint(Respawnpoint);
    }


}
