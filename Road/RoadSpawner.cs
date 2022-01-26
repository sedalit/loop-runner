using UnityEngine;

public class RoadSpawner : Spawner
{
    [SerializeField] private Road[] allRoads;
    [SerializeField] private float spaceBetweenRoads;

    private void Awake()
    {
        foreach (var road in allRoads)
        {
            Initialize(road.gameObject);
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= secondsBetweenSpawn)
        {
            if (TryGetObject(out Road road))
            {
                elapsedTime = 0;
                SetObject(road, new Vector3(spawnPoints[0].position.x, spawnPoints[0].position.y, spawnPoints[0].position.z + spaceBetweenRoads));
                spawnPoints[0] = road.NextRoadSpawnPoint;
            }
            
        }
    }

    protected override void OnDistanceFactorUpdated()
    {
        base.OnDistanceFactorUpdated();
        if (spaceBetweenRoads <= 4f) spaceBetweenRoads += 0.05f;
        elapsedTime = secondsBetweenSpawn;
    }
}
