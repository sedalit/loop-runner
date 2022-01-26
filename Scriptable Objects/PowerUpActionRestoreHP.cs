using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Power Up/Actions/Restore HP")]
public class PowerUpActionRestoreHP : PowerUpAction
{
    [SerializeField] private int hitPointsBonus;
    public override void Action(Player player)
    {
        player.RestoreHitPoints(hitPointsBonus);
    }

    public override IEnumerator AddTemporaryEffect(Player player, float bonus, float duration)
    {
        return null;
    }
}
