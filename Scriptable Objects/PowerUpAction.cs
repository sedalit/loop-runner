using System.Collections;
using UnityEngine;

public abstract class PowerUpAction : ScriptableObject
{
    public abstract void Action(Player player);
    public abstract IEnumerator AddTemporaryEffect(Player player, float bonus, float duration);
}
