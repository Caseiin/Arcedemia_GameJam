using UnityEngine;


public interface IMovementStrategy
{
    void StartUp();
    void UpdateDirection(Vector2 direction);
    void Move();
    void CleanUp();
}
