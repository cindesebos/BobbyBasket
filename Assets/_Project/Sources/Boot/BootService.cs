using Zenject;
using Sources.Services;
using Sources.Services.Score;
using Sources.Services.Master;

namespace Sources.Boot
{
    public class BootService : IInitializable
    {
        private const Scenes SceneToLoad = Scenes.MainMenu;

        private readonly SceneLoader _sceneLoader;
        private readonly IScoreService _scoreService;
        private readonly IMasterService _masterService;

        [Inject]
        public BootService(SceneLoader sceneLoader, IScoreService scoreService, IMasterService masterService)
        {
            _sceneLoader = sceneLoader;
            _scoreService = scoreService;
            _masterService = masterService;
        }

        public async void Initialize()
        {
            _scoreService.Load();
            _masterService.Load();

            await _sceneLoader.LoadScene(SceneToLoad);
        }
    }
}