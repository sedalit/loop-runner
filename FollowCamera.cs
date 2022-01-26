using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float offsetY = 2.224f;
    [SerializeField] private float offsetZ = 4.5f;

    private void Update()
    {
        transform.position = new Vector3(0, offsetY, targetTransform.position.z - offsetZ);
    }

}
