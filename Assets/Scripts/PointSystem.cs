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

    public void SetCurrentScore(int points)
    {

    }

    public void SetLatestScore(int points)
    {

    }

    public void SetBestScore(int points)
    {

    }

    public int GetLatestScore()
    {
        return latestScore;
    }

    public int GetBestScore()
    {
        return bestScore;
    }
}
