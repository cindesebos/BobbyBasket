using UnityEngine;
using Sources.Gameplay.ItemsBuilder;
using Zenject;

namespace Sources.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private ItemsSpawner _itemsSpawner;

        [Inject]
        private void Construct(ItemsSpawner itemsSpawner)
        {
            _itemsSpawner = itemsSpawner;
        }

        private void Awake()
        {
            _itemsSpawner.StartWork();
        }
    }
}
