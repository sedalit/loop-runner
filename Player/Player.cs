using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;
    public event UnityAction<float> SpeedChanged;

    [SerializeField] private int maxHealth;
    [SerializeField] private float maxDistanceFactor = 10f;
    [SerializeField] private float distanceFactorStep = 0.4f;
    [SerializeField] private PlayerMover mover;
    [SerializeField] private UnityEvent distanceFactorUpdated;

    private int currentHealth;
    private float distanceFactor = 0.75f;
    private float score = 0;
    private float maxScore;

    public int MaxHealth => maxHealth;
    public float DistanceFactor => distanceFactor;
    public float CurrentScore => score;
    public float MaxScore => maxScore;

    private void Awake()
    {
        Instance = this;
        Saver<float>.TryLoad("Saved game", ref maxScore);
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        score += distanceFactor * Time.deltaTime;
    }
   
    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        HealthChanged?.Invoke(currentHealth);
        SoundManager.Play(SoundManager.Instance.DamageTaken);
        if (currentHealth <= 0) Die();
    }

    public void RestoreHitPoints(int restored)
    {
        currentHealth += restored;
        HealthChanged?.Invoke(currentHealth);
    }

    public void Die()
    {
        mover.SetMovementSpeed(0);
        if (score > maxScore)
        {
            maxScore = score;
            Saver<float>.Save("Saved game", maxScore);
        }
        Died?.Invoke();
    }

    public void UpdateDistanceFactor()
    {
        if (distanceFactor >= maxDistanceFactor) return;
        distanceFactor += distanceFactorStep;
        distanceFactorUpdated?.Invoke();
    }
    public float GetMovementSpeed()
    {
        return mover.MovementSpeed;
    }

    public void AddMovementSpeed(float bonus)
    {
        SpeedChanged?.Invoke(bonus);
        mover.AddMovementSpeed(bonus);
    }

    public void SetMovementSpeed(float speed)
    {
        mover.SetMovementSpeed(speed);
    }
}
