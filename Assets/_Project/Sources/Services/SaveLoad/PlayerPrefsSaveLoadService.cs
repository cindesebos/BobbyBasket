using UnityEngine;
using Sources.Services.Score;

namespace Sources.Services.SaveLoad
{
    public class PlayerPrefsSaveLoadService : ISaveLoadService
    {
        private const string ScoreKey = "playerScore";

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
    }
}