using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Power Up/Actions/Add Velocity")]
public class PowerUpActionAddVelocity : PowerUpAction
{
    [SerializeField] private float velocityBonus;
    [SerializeField] private float duration;
    private float speedBeforeBonus;
    public override void Action(Player player)
    {
        speedBeforeBonus = player.GetMovementSpeed();
        player.StartCoroutine(AddTemporaryEffect(player, velocityBonus, duration));
    }

    public override IEnumerator AddTemporaryEffect(Player player, float bonus, float duration)
    {
        player.AddMovementSpeed(bonus);
        yield return new WaitForSeconds(duration);
        player.SetMovementSpeed(speedBeforeBonus);

    }
}
