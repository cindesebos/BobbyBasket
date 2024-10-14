using System.Collections.Generic;
using UnityEngine;
using Sources.Gameplay.Items;

namespace Sources.Gameplay.ItemsBuilder
{
    [CreateAssetMenu(menuName = "Source/Datas/ItemsSpawner", fileName = "ItemsSpawnerData", order = 0)]
    public class ItemsSpawnerData : ScriptableObject
    {
        [SerializeField] private List<Item> _items = new List<Item>();
        [SerializeField] private float _spawnCooldown;

        public IEnumerable<Item> Items => _items;
        public float SpawnCooldown => _spawnCooldown;
    }
}