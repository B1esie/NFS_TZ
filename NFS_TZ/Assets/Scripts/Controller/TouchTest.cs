
using UnityEngine;
using UnityEngine.EventSystems;
public class TouchTest : MonoBehaviour,IDragHandler
{

    Vector2 startPos;
    Vector2 direction;
    Vector3 CurrentAngle;
    private float maxRotate=90.0f;
   private PointerEventData ban;
    private Rigidbody rigidbody;
    private float bbb;
    public void OnDrag(PointerEventData eventData)
    {
      
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 )
        {
            Touch first = Input.GetTouch(0);
            if (first.phase==TouchPhase.Began)
            {
                startPos = first.position;

            }

            if (first.phase == TouchPhase.Moved)
            {
                direction = first.position - startPos;
                bbb = Mathf.Abs(direction.x - direction.y);


            }
            if (first.phase == TouchPhase.Ended)
            {
                if (first.deltaPosition.y < 0)
                {
                  
                    Debug.Log(Vector3.forward * direction);
                    rigidbody.AddForce(Vector3.forward*bbb, ForceMode.Impulse);
                }
            }
        }
        }

    }
           

   

    