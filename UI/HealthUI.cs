using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text healthText;
    private int lastValue;

    private void Start()
    {
        lastValue = player.MaxHealth;
        healthText.text = lastValue.ToString();
    }

    private void OnEnable()
    {
        player.HealthChanged += OnHealthChanged;
    }
    private void OnDisable()
    {
        player.HealthChanged -= OnHealthChanged;
    }
    private void OnHealthChanged(int health)
    {
        if (lastValue > health) ChangeColor(Color.red);
        if (lastValue < health) ChangeColor(Color.green);
        lastValue = health;
        healthText.text = health.ToString();
    }
    private void ChangeColor(Color color)
    {
        healthText.DOColor(color, 0.5f).SetLoops(2, LoopType.Yoyo);
    }
}
