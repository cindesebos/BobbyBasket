using UnityEngine;
using Sources.Gameplay.Common;
using Zenject;

namespace Sources.Gameplay.Items
{
    public sealed class Coin : Item
    {
        private CoinsHandler _coinsHandler;

        [SerializeField] private int _amount;

        [Inject]
        private void Construct(ItemsSFX itemsSFX, CoinsHandler coinsHandler)
        {
            base.Construct(itemsSFX);
            _coinsHandler = coinsHandler;
        }

        public override void PickUp() => _coinsHandler.OnPickedUpCoin(_amount);
    }
}