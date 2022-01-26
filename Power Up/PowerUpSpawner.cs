using UnityEngine;

public class PowerUpSpawner : Spawner
{
    [SerializeField] private PowerUp[] allPowerUps;
    private void Awake()
    {
        foreach (var powerUp in allPowerUps)
        {
            Initialize(powerUp.gameObject);
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= secondsBetweenSpawn)
        {
            if (TryGetObject(out PowerUp powerUp))
            {
                elapsedTime = 0;
                int spawnPointNumber = Random.Range(0, spawnPoints.Length);
                Vector3 position = spawnPoints[spawnPointNumber].position;
                SetObject(powerUp, position);
            }

        }
    }
}
