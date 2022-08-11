using UnityEngine;

public class FollowCamera : MonoBehaviour
{
   [SerializeField] private Transform target;
    [SerializeField] private Vector3 cameraOffset;
    private float smoothFactor = 0.5f;

    private void Start()
    {
        cameraOffset = (transform.position - target.transform.position);
    }
    private void LateUpdate()
    {
        Vector3 newPosition = target.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
          transform.LookAt(target);
        
    }
}