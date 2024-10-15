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
        [SerializeField] private int _numberOfEachItems;

        private ItemsSpawnerData _data;
        private SpawnerFactory _spawnerFactory;

        private List<Item> _items = new List<Item>();
        private Item[] _itemPrefabs;

        [Inject]
        private void Construct(ItemsSpawnerData data, SpawnerFactory spawnerFactory)
        {
            _data = data;
            _spawnerFactory = spawnerFactory;
        }

        private void Start()
        {
            Init();

            foreach (Item prefab in _itemPrefabs)
            {
                for (int i = 0; i < _numberOfEachItems; i++) CreateItem(prefab, transform.position);
            }
        }

        private void Init()
        {
            Item[] convertedItems = _data.Items.ToArray<Item>();

            _itemPrefabs = new Item[convertedItems.Length];

            for (int i = 0; i < _itemPrefabs.Length; i++) _itemPrefabs[i] = convertedItems[i];
        }

        private Item CreateItem(Item prefab, Vector2 position, bool isHideItem = false)
        {
            Item spawnedItem = _spawnerFactory.SpawnItem(prefab, position, transform);

            spawnedItem.gameObject.SetActive(isHideItem);

            _items.Add(spawnedItem);

            return spawnedItem;
        }

        public Item GetFreeItemByType(Item prefab, Vector2 position)
        {
            foreach (Item item in _items)
            {
                if (prefab.GetType() == item.GetType() && !item.gameObject.activeInHierarchy)
                {
                    item.gameObject.SetActive(true);
                    item.transform.position = position;
                    return item;
                }
            }

            return CreateItem(prefab, position, true);
        }

        public void HideAllItems()
        {
            foreach (Item prefab in _items) prefab.gameObject.SetActive(false);
        }
    }
}
