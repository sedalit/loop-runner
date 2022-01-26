using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform nextRoadSpawnPoint;
    private Camera mainCamera;
    public Transform NextRoadSpawnPoint => nextRoadSpawnPoint;
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        transform.position += -Vector3.forward * ((speed * Player.Instance.GetMovementSpeed()) * Player.Instance.DistanceFactor /2) * Time.deltaTime;
        if (nextRoadSpawnPoint.position.z < mainCamera.transform.position.z)
        {
            gameObject.SetActive(false);
            Player.Instance.UpdateDistanceFactor();
        }
    }
}
