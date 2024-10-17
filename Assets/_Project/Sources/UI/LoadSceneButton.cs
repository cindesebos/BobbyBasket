using UnityEngine;
using Zenject;
using UnityEngine.UI;
using Sources.Services;

namespace Sources.UI
{
    [RequireComponent(typeof(Button))]
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField] private Scenes _sceneToLoad;

        [Inject]
        private void Construct(SceneLoader sceneLoader) =>
            GetComponent<Button>().onClick.AddListener(async () =>
            {   
                await sceneLoader.LoadScene(_sceneToLoad);
            });
    }
}