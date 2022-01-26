using UnityEngine;

public class GameFieldMover : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private RoadSpawner roadSpawner;
    [SerializeField] private EnemySpawner enemySpawner;

    private void Update()
    {
        roadSpawner.transform.position = new Vector3(0, 0, player.transform.position.z + 15f);
        enemySpawner.transform.position = new Vector3(0, 0, player.transform.position.z + 15f);
    }
}
