public class PointSystem
{
    int bestScore = 0;
    int latestScore = 0;
    int currentScore = 0;

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public void AddPointsToCurrentScore(int points)
    {
        currentScore += points;
    }

    public void SetLatestScoreToCurrentScore()
    {
        latestScore = currentScore;

        if (latestScore > bestScore)
            bestScore = latestScore;
    }

    public PlayerDataStructure GetNewPlayerScore()
    {
        return new PlayerDataStructure() { CurrentScore = currentScore, LatestScore = latestScore, BestScore = bestScore };
    }
}
