using UnityEngine;

public interface IPlayer
{
    string PlayerName { get; }
    int Score { get; }

    event System.Action<int> ScoreChanged;
    void SetSprite(Sprite sprite);

    void Initialize(string name);
    void IncreaseScore(int points);
}
