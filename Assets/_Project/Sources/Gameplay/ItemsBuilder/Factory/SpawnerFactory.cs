using UnityEngine;
using Zenject;
using Sources.Gameplay.Items;

namespace Sources.Gameplay.ItemsBuilder.Factory
{
    public class SpawnerFactory
    {
        private readonly DiContainer _container;

        private const string CharacterPath = "Prefabs/Character";

        [Inject]
        public SpawnerFactory(DiContainer container) => _container = container;

        public Item SpawnItem(Item prefab, Vector3 spawnPosition, Transform parent = null)
        {
            var spawnedObject = _container.InstantiatePrefab(prefab, spawnPosition, Quaternion.identity, parent);

            return spawnedObject.GetComponent<Item>();
        }
    }
}