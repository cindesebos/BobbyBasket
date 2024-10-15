using UnityEngine;
using Zenject;
using Sources.UI;
using Sources.Gameplay.ItemsBuilder;

namespace Sources.Gameplay
{
    public class GameplayStateObserver
    {
        private readonly GameOverPopUp _gameOverPopUp;
        private readonly CharacterInput _characterInput;
        private readonly ItemsSpawner _itemsSpawner;
        private readonly ItemsPool _itemsPool;
        private readonly CoinCounter _coinCounter;

        [Inject]
        private GameplayStateObserver(GameOverPopUp gameOverPopUp, CharacterInput characterInput, 
        ItemsSpawner itemsSpawner, ItemsPool itemsPool, CoinCounter coinCounter)
        {
            _gameOverPopUp = gameOverPopUp;
            _characterInput = characterInput;
            _itemsSpawner = itemsSpawner;
            _itemsPool = itemsPool;
            _coinCounter = coinCounter;
        }

        public void OnGameOver()
        {
            _itemsPool.HideAllItems();
            _itemsSpawner.StopWork();
            _characterInput.Disable();
            _gameOverPopUp.Show(_coinCounter.Score);
        }
    }
}
