using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover mover;
    [SerializeField] private int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PowerUp powerUp)) return;
        if (other.TryGetComponent(out Player player))
        {
            player.ApplyDamage(damage);
        }
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
