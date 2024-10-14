using UnityEngine;
using Zenject;
using Sources.UI;

namespace Sources.Gameplay.Common
{
    public class CoinsHandler
    {
        private readonly CoinCounter _coinCounter;

        [Inject]
        public CoinsHandler(CoinCounter coinCounter)
        {
            _coinCounter = coinCounter;
        }

        public void OnPickedUpCoin(int amount) => _coinCounter.AddCoins(amount);
    }
}
