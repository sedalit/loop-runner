using UnityEngine;
public class CameraController : MonoBehaviour
{
   [SerializeField] private Camera targetCamera;
   [SerializeField] private Transform targetTransform;
   [SerializeField] private float interpolationLinear;
   [SerializeField] private float interpolationAngular;
   [SerializeField] private float cameraOffset;
   [SerializeField] private float forwardOffset;
   private void FixedUpdate() {
       if(targetTransform == null || targetCamera == null) return;
       Vector3 camPos = targetCamera.transform.position;
       Vector3 targetPos = targetTransform.position + targetTransform.transform.up * forwardOffset;
       Vector3 newCamPos = Vector3.Lerp(camPos, targetPos, interpolationLinear * Time.deltaTime);
       targetCamera.transform.position = new Vector3(newCamPos.x, newCamPos.y, targetCamera.transform.position.z);
       if(interpolationAngular > 0)
       {
           targetCamera.transform.rotation = Quaternion.Slerp(targetCamera.transform.rotation, targetTransform.rotation, 
                                                                interpolationAngular * Time.deltaTime);
       }
   }

   public void SetTarget(Transform newTarget)
   {
       targetTransform = newTarget;
   }
}
