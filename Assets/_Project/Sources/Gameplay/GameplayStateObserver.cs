using Zenject;
using Sources.UI;
using Sources.Gameplay.ItemsBuilder;
using Sources.Services.Score;

namespace Sources.Gameplay
{
    public class GameplayStateObserver
    {
        private readonly GameOverPopUp _gameOverPopUp;
        private readonly CharacterInput _characterInput;
        private readonly ItemsSpawner _itemsSpawner;
        private readonly ItemsPool _itemsPool;
        private readonly CoinCounter _coinCounter;
        private readonly IScoreService _scoreService;

        [Inject]
        private GameplayStateObserver(GameOverPopUp gameOverPopUp, CharacterInput characterInput, 
        ItemsSpawner itemsSpawner, ItemsPool itemsPool, CoinCounter coinCounter, IScoreService scoreService)
        {
            _gameOverPopUp = gameOverPopUp;
            _characterInput = characterInput;
            _itemsSpawner = itemsSpawner;
            _itemsPool = itemsPool;
            _coinCounter = coinCounter;
            _scoreService = scoreService;
        }

        public void OnGameOver()
        {
            int score = _coinCounter.Score;
            _itemsPool.HideAllItems();
            _itemsSpawner.StopWork();
            _characterInput.Disable();
            _scoreService.SetMaxScore(score);
            _gameOverPopUp.Show(score);
        }
    }
}
