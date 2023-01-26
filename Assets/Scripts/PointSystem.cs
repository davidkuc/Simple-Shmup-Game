public class PointSystem
{
    int bestScore = 0;
    int latestScore = 0;
    int currentScore = 0;

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public void AddPointsToCurrentScore(int points)
    {
        currentScore += points;
        latestScore = currentScore;

        if (latestScore > bestScore)
            bestScore = latestScore;
    }

    public PlayerDataStructure GetScoreData()
    {
        return new PlayerDataStructure() { CurrentScore = currentScore, LatestScore = latestScore, BestScore = bestScore };
    }

    public void LoadScore(PlayerDataStructure playerDataStructure)
    {
        latestScore = playerDataStructure.LatestScore;
        bestScore = playerDataStructure.BestScore;
    }
}
