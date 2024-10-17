using Sources.Services.Score;

namespace Sources.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void Save(ScoreData data);

        ScoreData LoadScoreData();
    }
}