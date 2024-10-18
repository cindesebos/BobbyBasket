using UnityEngine;
using Sources.Services.Score;
using Sources.Services.Master;

namespace Sources.Services.SaveLoad
{
    public class PlayerPrefsSaveLoadService : ISaveLoadService
    {
        private const string ScoreKey = "scoreData";
        private const string MasterKey = "masterData";

        public void Save(ScoreData data)
        {
            string jsonData = JsonUtility.ToJson(data);
            Debug.Log("Saving data: " + jsonData);

            PlayerPrefs.SetString(ScoreKey, jsonData);
            PlayerPrefs.Save();
        }

        public ScoreData LoadScoreData()
        {
            if (PlayerPrefs.HasKey(ScoreKey))
            {
                string jsonData = PlayerPrefs.GetString(ScoreKey);
                Debug.Log("Loaded data: " + jsonData);

                return JsonUtility.FromJson<ScoreData>(jsonData);
            }

            return new ScoreData(0);
        }

        public void Save(MasterData data)
        {
            string jsonData = JsonUtility.ToJson(data);
            Debug.Log("Saving data: " + jsonData);

            PlayerPrefs.SetString(MasterKey, jsonData);
            PlayerPrefs.Save();
        }

        public MasterData LoadMasterData()
        {
            if (PlayerPrefs.HasKey(MasterKey))
            {
                string jsonData = PlayerPrefs.GetString(MasterKey);
                Debug.Log("Loaded data: " + jsonData);

                return JsonUtility.FromJson<MasterData>(jsonData);
            }

            return new MasterData(0);
        }
    }
}