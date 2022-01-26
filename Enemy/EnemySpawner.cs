using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] private Enemy[] enemiesPrefabs;
    [SerializeField] private float spawnPointOffset = 5;

    private void Awake()
    {
        foreach (var enemyPrefab in enemiesPrefabs)
        {
            Initialize(enemyPrefab.gameObject);
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= secondsBetweenSpawn)
        {
            if (TryGetObject(out Enemy enemy))
            {
                elapsedTime = 0;
                int spawnPointNumber = Random.Range(0, spawnPoints.Length);
                SetObject(enemy, spawnPoints[spawnPointNumber].position + new Vector3(0, 0, spawnPointOffset));
            }
        }
    }
}
