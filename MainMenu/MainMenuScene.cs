using UnityEngine;

public class MainMenuScene : MonoBehaviour
{
    
    [SerializeField] private FallingCube spawnPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private FallingCubeCounterUI counterUI;
    private float elapsedTime = 0;

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 0.5f)
        {
            elapsedTime = 0;
            FallingCube spawned = Instantiate(spawnPrefab, new Vector3(Random.Range(-6f, 6f), spawnPoint.position.y, spawnPoint.position.z), Quaternion.identity);
            spawned.CubeDestroyed.AddListener(counterUI.OnCubeDestroyed);
        }
    }
}
