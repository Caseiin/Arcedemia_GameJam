using System;
using UnityEngine;

public class CheckPointMark : MonoBehaviour
{
    public static event Action onCheckPointEnter;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player"))
        {
            onCheckPointEnter?.Invoke();
           Debug.Log("CheckPoint marked"); 
        }
    }
}
