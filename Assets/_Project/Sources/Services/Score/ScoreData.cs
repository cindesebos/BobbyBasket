namespace Sources.Services.Score
{
    [System.Serializable]
    public class ScoreData
    {
        public int MaxScore;
        public ScoreData(int score) => MaxScore = score;
    }
}