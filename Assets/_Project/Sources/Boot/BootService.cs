using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using Sources.Services;

namespace Sources.Boot
{
    public class BootService : IInitializable
    {
        private const Scenes SceneToLoad = Scenes.MainMenu;

        private readonly SceneLoader _sceneLoader;

        public BootService(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async void Initialize()
        {
            await _sceneLoader.LoadScene(SceneToLoad);
        }
    }
}