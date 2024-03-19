using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    public string PlayerName { get; private set; }
    public int Health { get; private set; }
    public int Score { get; private set; }

    public event System.Action<int> HealthChanged;
    public event System.Action<int> ScoreChanged;

    // Method to initialize player data
    public void Initialize(string name)
    {
        PlayerName = name;
        Score = 0;
    }

    // Method to reduce player's health
    public void TakeDamage(int damage)
    {
        Health -= damage;
        HealthChanged?.Invoke(Health);
        // Handle player's death or other effects here
    }

    // Method to increase player's score
    public void IncreaseScore(int points)
    {
        Score += points;
        ScoreChanged?.Invoke(Score);
    }

    public void SetSprite(Sprite sprite)
    {
        throw new System.NotImplementedException();
    }
}
