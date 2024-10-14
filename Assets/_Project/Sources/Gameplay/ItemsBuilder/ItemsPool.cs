using UnityEngine;
using System.Collections.Generic;
using Zenject;
using Sources.Gameplay.Items;
using Sources.Gameplay.ItemsBuilder.Factory;
using System.Linq;

namespace Sources.Gameplay.ItemsBuilder
{
    public class ItemsPool : MonoBehaviour
    {
        [SerializeField] private ItemsSpawnerData _data;
        [SerializeField] private SpawnerFactory _spawnerFactory;

        [SerializeField] private List<Item> _items = new List<Item>();

        [SerializeField] private Item[] _itemPrefabs;

        [Inject]
        private void Construct(ItemsSpawnerData data, SpawnerFactory spawnerFactory)
        {
            _data = data;
            _spawnerFactory = spawnerFactory;
        }

        private void Start() => Init();

        private void Init()
        {
            Item[] convertedItems = _data.Items.ToArray<Item>();

            _itemPrefabs = new Item[convertedItems.Length];

            for(int i=0; i<_itemPrefabs.Length; i++) _itemPrefabs[i] = convertedItems[i];
        }

        private Item CreateItem(Vector2 position)
        {
            Item prefab = _itemPrefabs[Random.Range(0, _itemPrefabs.Length)];

            Item spawnedItem = _spawnerFactory.SpawnItem(prefab, position, transform);

            _items.Add(spawnedItem);

            return spawnedItem;
        }

        public Item GetFreeItem(Vector2 position)
        {
            foreach (Item item in _items)
            {
                if (!item.gameObject.activeInHierarchy)
                {
                    item.gameObject.SetActive(true);
                    item.transform.position = position;
                    return item;
                }
            }

            return CreateItem(position);
        }
    }
}
