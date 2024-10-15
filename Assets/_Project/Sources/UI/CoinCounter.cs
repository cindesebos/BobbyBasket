using System;
using TMPro;
using UnityEngine;

namespace Sources.UI
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public int Score { get; private set;}

        public void AddCoins(int score)
        {
            if(score < 0) throw new ArgumentOutOfRangeException();

            Score += score;

            _text.text = Score.ToString();
        }
    }
}
