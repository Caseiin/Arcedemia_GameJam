using UnityEngine;

public class CheckPointOriginator : MonoBehaviour
{
    public CheckPointMemento SaveCheckPoint()
    {
        return new CheckPointMemento(transform.position);
    }

    public void  RestoreCheckPoint(CheckPointMemento checkPoint)
    {
        transform.position = checkPoint.CheckPoint;
    }    
}
