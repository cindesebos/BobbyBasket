using UnityEngine;

namespace Sources.Services.Score
{
    [System.Serializable]
    public class ScoreData
    {
        [SerializeField] private int _maxScore;

        public ScoreData(int score) => _maxScore = score;

        public int GetMaxScore() => _maxScore;
    }
}