using UnityEngine;
public class BaseCar : MonoBehaviour, IECar
{
    [SerializeField] Transform carTransform;
    private Vector2 startPosition;
    private Vector2 direction;
    private Rigidbody rigidbody;
    private Vector3 respawnPosition;

    int f = 0;
    private int screenHeight;

    private void Start()
    {
        respawnPosition = carTransform.transform.position;
        rigidbody = GetComponent<Rigidbody>();
        Debug.Log(respawnPosition);
        screenHeight = Screen.height / 2;
    }
 
    public void carDie()
    {
        if (carTransform.position.y < -1)
        {

            carTransform.position = respawnPosition;
            carTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    public void carMove()
    {
        if (Input.touchCount > 0)
        {
            Touch first = Input.GetTouch(0);
           
            switch (first.phase)
            {
                case TouchPhase.Began:
                    startPosition = first.position;
                    break;
                case TouchPhase.Moved:
                   
                    break;
                case TouchPhase.Ended:
                    direction = first.position - startPosition;
                    Debug.Log(direction);
                    Vector3 forward = transform.TransformDirection(Vector3.forward);
                    rigidbody.AddForce(forward * Mathf.Abs(directionTranslate(direction))*3 * Time.deltaTime, ForceMode.Impulse);
                    break;
            }
        }
    }

    public void carRotate()
    {
        if (Input.touchCount > 0)
        {
            Touch first = Input.GetTouch(0);

            switch (first.phase)
            {
                case TouchPhase.Began:
                    startPosition = first.position;
                    break;
                case TouchPhase.Moved:
                    direction = first.position - startPosition;
                    
                    carTransform.Rotate(0, directionTranslate(direction) * Time.deltaTime, 0);                 
                    break;
                case TouchPhase.Ended:
                    break;
            }
        }
    }
 
    public float directionTranslate(Vector2 direction)
    {
        float result;
        float differencedirection;
        differencedirection = (direction.x - direction.y);
        result = differencedirection;
        return result;
    }
}
