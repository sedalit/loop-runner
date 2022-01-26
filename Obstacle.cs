using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private enum PlayerAction
    {
        Jump, Seat
    }
    [SerializeField] private PlayerAction playerAction;
    [SerializeField] private int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.ApplyDamage(damage);
            if (playerAction == PlayerAction.Jump) player.GetComponent<PlayerMover>().TryJump();
            if (playerAction == PlayerAction.Seat) player.GetComponent<PlayerMover>().TrySeat();
        }
    }
}
