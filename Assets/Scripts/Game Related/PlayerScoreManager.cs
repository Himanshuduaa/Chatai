public class PlayerScoreManager
{
    // Method to call a function on a specific player to increase their score
    public static void IncreaseScore(IPlayer player, int points)
    {
        player.IncreaseScore(points);
    }
}
