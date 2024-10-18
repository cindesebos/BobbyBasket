using Zenject;
using UnityEngine;
using Sources.Gameplay.Items;
using System.Collections.Generic;

namespace Sources.Gameplay.ItemsBuilder
{
    public class ItemsSpawner : ITickable
    {
        private readonly ItemsSpawnerData _data;
        private readonly ItemsPool _itemsPool;

        private readonly float _maxSpawnCooldown;
        private readonly Transform[] _spawnPoints;
        private readonly List<Item> _itemPrefabs = new List<Item>();

        private bool _isWorking;
        private float _spawnCooldown;

        [Inject]
        public ItemsSpawner(ItemsSpawnerData data, ItemsPool itemsPool, Transform[] spawnPoints)
        {
            _data = data;
            _itemsPool = itemsPool;
            _spawnPoints = spawnPoints;

            foreach(Item item in _data.Items) _itemPrefabs.Add(item);
            _maxSpawnCooldown = _data.SpawnCooldown;
            _spawnCooldown = _maxSpawnCooldown;
        }


        public void Tick()
        {
            if (!_isWorking) return;

            if (_spawnCooldown <= 0)
            {
                _spawnCooldown = _maxSpawnCooldown;

                SpawnItem();
            }
            else _spawnCooldown -= Time.deltaTime;
        }

        private void SpawnItem()
        {
            Item prefab = _itemPrefabs[Random.Range(0, _itemPrefabs.Count)];

            Vector2 spawnPosition = new Vector2(Random.Range(GetSpawnpointPositionXByIndex(0), GetSpawnpointPositionXByIndex(1)), GetSpawnpointPositioYXByIndex(0));

            _itemsPool.GetFreeItemByType(prefab, spawnPosition);
        }

        private float GetSpawnpointPositionXByIndex(int index) => _spawnPoints[index].transform.position.x;
        private float GetSpawnpointPositioYXByIndex(int index) => _spawnPoints[index].transform.position.y;

        public void StartWork() => _isWorking = true;

        public void StopWork() => _isWorking = false;
    }
}
