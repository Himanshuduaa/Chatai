using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IPlayer player1;
    private IPlayer player2;

    private void Start()
    {
        // Initialize players
        player1 = new Player();
        player1.Initialize("Player 1");
        player1.ScoreChanged += OnPlayerScoreChanged;

        player2 = new Player();
        player2.Initialize("Player 2");
        player2.ScoreChanged += OnPlayerScoreChanged;

        // Increase player 1's score by 10
        PlayerScoreManager.IncreaseScore(player1, 10);
        PlayerScoreManager.IncreaseScore(player2, 10);
    }

    private void OnPlayerScoreChanged(int newScore)
    {
        Debug.Log("Player's score changed: " + newScore);
    }
}
