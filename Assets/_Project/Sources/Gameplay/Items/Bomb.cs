using UnityEngine;
using Zenject;

namespace Sources.Gameplay.Items
{
    public sealed class Bomb : Item
    {
        private GameplayStateObserver _gameplayStateObserver;

        [SerializeField] private int _amount;

        [Inject]
        private void Construct(ItemsSFX itemsSFX, GameplayStateObserver gameplayStateObserver)
        {
            base.Construct(itemsSFX);
            _gameplayStateObserver = gameplayStateObserver;
        }

        public override void PickUp() => _gameplayStateObserver.OnGameOver();
    }
}