using UnityEngine;
using UnityEngine.Events;

public class FallingCube : MonoBehaviour
{
    public UnityEvent CubeDestroyed;
    private void Update()
    {
        transform.Rotate(new Vector3(Random.value, Random.value, Random.value));
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        SoundManager.Play(SoundManager.Instance.TapSound);
        CubeDestroyed?.Invoke();
        Destroy(gameObject);
    }
}
