using UnityEngine;
using Zenject;
using Sources.Gameplay;

namespace Sources.Gameplay.Items
{
    public sealed class Bomb : Item
    {
        private GameplayStateObserver _gameplayStateObserver;

        [SerializeField] private int _amount;

        [Inject]
        protected void Construct(ItemsSFX itemsSFX, GameplayStateObserver gameplayStateObserver)
        {
            base.Construct(itemsSFX);
            _gameplayStateObserver = gameplayStateObserver;
        }

        public override void PickUp()
        {
            Debug.Log($"Character picked up a bomb");

            _gameplayStateObserver.OnGameOver();
        }
    }
}