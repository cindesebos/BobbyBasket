using System;
using TMPro;
using UnityEngine;

namespace Sources.UI
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private int _score;

        public void AddCoins(int score)
        {
            if(score < 0) throw new ArgumentOutOfRangeException();

            _score += score;

            _text.text = _score.ToString();
        }
    }
}
