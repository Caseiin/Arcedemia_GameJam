using System;
using UnityEngine;
using UnityEngine.Events;

public class CheckPointMark : MonoBehaviour
{

    public UnityEvent onCheckPointMark;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
            onCheckPointMark?.Invoke();
           Debug.Log("CheckPoint marked"); 
        }
    }
}
