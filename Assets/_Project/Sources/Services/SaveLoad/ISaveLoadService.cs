using Sources.Services.Master;
using Sources.Services.Score;

namespace Sources.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void Save(ScoreData data);

        ScoreData LoadScoreData();

        void Save(MasterData data);

        MasterData LoadMasterData();
    }
}