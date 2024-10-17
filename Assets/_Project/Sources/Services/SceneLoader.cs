using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Sources.Services
{
    public class SceneLoader
    {
        public event Action StartLoadingScene;
        public event Action EndLoadingScene;
    
        public async UniTask LoadScene(Scenes scene)
        {
            StartLoadingScene?.Invoke();

            string sceneName = scene.ToString();

            AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            await loadSceneOperation.ToUniTask();

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

            EndLoadingScene?.Invoke();
        }
    }
}