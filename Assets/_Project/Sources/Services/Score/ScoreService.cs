using Zenject;
using System;
using Sources.Services.SaveLoad;
using UnityEngine;

namespace Sources.Services.Score
{
    public class ScoreService : IScoreService
    {
        private readonly ISaveLoadService _saveLoadService;

        private int _maxScore;

        [Inject]
        public ScoreService(ISaveLoadService saveLoadService) => _saveLoadService = saveLoadService;

        public int MaxScore
        {
            get => _maxScore;
            set
            {
                if (value < 0 || _maxScore > value) return;

                _maxScore = value;

                Save();
            }
        }

        public void SetMaxScore(int score) => MaxScore = score;

        public void Save()
        {
            ScoreData data = new ScoreData(MaxScore);
            _saveLoadService.Save(data);
        }

        public void Load()
        {
            ScoreData data = _saveLoadService.LoadScoreData();

            MaxScore = data != null ? data.MaxScore : 0;
        }
    }
}