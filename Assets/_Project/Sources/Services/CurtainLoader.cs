using Zenject;
using System;

namespace Sources.Services
{
    public class CurtainLoader : IDisposable
    {
        private readonly CurtainView _view;
        private readonly SceneLoader _sceneLoader;

        [Inject]
        public CurtainLoader(CurtainView view, SceneLoader sceneLoader)
        {
            _view = view;
            _sceneLoader = sceneLoader;

            _sceneLoader.StartLoadingScene += OnStartLoadingScene;
            _sceneLoader.EndLoadingScene += OnEndLoadingScene;
        }

        public void Dispose()
        {
            _sceneLoader.StartLoadingScene -= OnStartLoadingScene;
            _sceneLoader.EndLoadingScene -= OnEndLoadingScene;
        }

        public void OnStartLoadingScene() => _view.Show();

        public void OnEndLoadingScene() => _view.Hide();
    }
}