namespace Sources.Services.Score
{
    public interface IScoreService
    {
        int MaxScore { get; }
        void SetMaxScore(int score);
        void Save();
        void Load();
    }
}