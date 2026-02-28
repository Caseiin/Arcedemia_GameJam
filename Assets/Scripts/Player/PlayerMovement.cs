using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputReaderSO input;


    void Update()
    {
        Debug.Log(input.Move);
    }

    void OnEnable()
    {
        if (input != null) input.EnableMap();
    }

    void OnDisable()
    {
        if (input != null) input.DisableMap();

    }
}
