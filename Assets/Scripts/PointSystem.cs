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

    public void SetCurrentScoreToLatestScore()
    {
        latestScore = currentScore;

        if (latestScore > bestScore)
            SetBestScore(latestScore);
    }

    public void SetBestScore(int points)
    {
        bestScore = points;
    }

    public PlayerDataStructure GetNewPlayerScore()
    {
        return new PlayerDataStructure() { LatestScore = latestScore, BestScore = bestScore };
    }
}
