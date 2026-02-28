using System;
using UnityEngine;

public class CheckPointMark : MonoBehaviour
{
    public static event Action onCheckPointEnter;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
            onCheckPointEnter?.Invoke();
           Debug.Log("CheckPoint marked"); 
        }
    }
}
