using UnityEngine;

public abstract class Spawner : ObjectPool
{
    [SerializeField] protected Transform[] spawnPoints;
    protected float elapsedTime = 0;
}
