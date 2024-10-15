using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Sources.Services
{
    public class SceneLoader
    {
        public async UniTask LoadScene(Scenes scene)
        {
            string sceneName = scene.ToString();

            AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            await loadSceneOperation.ToUniTask();

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }
    }
}