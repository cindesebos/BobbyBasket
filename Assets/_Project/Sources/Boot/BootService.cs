using Zenject;
using Sources.Services;
using Sources.Services.Score;
using UnityEngine;

namespace Sources.Boot
{
    public class BootService : IInitializable
    {
        private const Scenes SceneToLoad = Scenes.MainMenu;

        private readonly SceneLoader _sceneLoader;
        private readonly IScoreService _scoreService;

        [Inject]
        public BootService(SceneLoader sceneLoader, IScoreService scoreService)
        {
            _sceneLoader = sceneLoader;
            _scoreService = scoreService;
        }

        public async void Initialize()
        {
            _scoreService.Load();

            await _sceneLoader.LoadScene(SceneToLoad);
        }
    }
}