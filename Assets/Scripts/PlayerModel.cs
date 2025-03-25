using System;

public class PlayerModel
{
    public event Action<int> OnHealthChange;
    public event Action OnPlayerDeath;

    private const float MoveSpeed = 5f;

    public float moveSpeed => MoveSpeed;

    public PlayerModel(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        CurrentHealth = Math.Clamp(CurrentHealth + amount, 0, MaxHealth);

        OnHealthChange?.Invoke(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            OnPlayerDeath?.Invoke();
        }
    }

    private int CurrentHealth { get; set; }

    public int MaxHealth { get; }
}