
using UnityEngine;

public interface IECar
{
    void carMove();
    void carRotate();
    void carDie();
    float directionTranslate(Vector2 direction);
}
