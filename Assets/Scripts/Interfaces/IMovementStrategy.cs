using UnityEngine;


public interface IMovementStrategy
{

    void UpdateDirection(Vector2 direction);
    void Move();
    void CleanUp();
}
