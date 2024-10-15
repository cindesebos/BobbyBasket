using UnityEngine;
using Zenject;
using Sources.Gameplay.ItemsBuilder;
using Sources.Gameplay.ItemsBuilder.Factory;
using Sources.UI;
using Sources.Gameplay.Common;

namespace Sources.Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private ItemsPool _itemsPool;
        [Space]

        [SerializeField] private GameOverPopUp _gameOverPopUp;
        [Space]

        [SerializeField] private CoinCounter _coinCounter;

        [SerializeField] private ItemsSpawnerData _data;
        [SerializeField] private Transform[] _spawnPoints;

        public override void InstallBindings()
        {
            BindCharacterInput();
            BindSpawnerFactory();
            BindItemsPool();
            BindItemsSpawner();
            BindCoinCounter();
            BindCoinsHandler();
            BindGameplayStateObserver();
            BindGameOverPopUp();
        }

        private void BindCharacterInput()
        {
            Container.BindInterfacesAndSelfTo<CharacterInput>()
                .AsSingle();
        }

        private void BindItemsSpawner()
        {
            Container.Bind<ItemsSpawnerData>()
                .FromInstance(_data)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<ItemsSpawner>()
                .AsSingle();
        }

        private void BindSpawnerFactory()
        {
            Container.Bind<Transform[]>()
                    .FromInstance(_spawnPoints)
                    .AsSingle();

            Container.BindInterfacesAndSelfTo<SpawnerFactory>()
                .AsSingle();
        }

        private void BindItemsPool()
        {
            Container.Bind<ItemsPool>()
                .FromInstance(_itemsPool)
                .AsSingle();
        }

        private void BindCoinCounter()
        {
            Container.Bind<CoinCounter>()
                .FromInstance(_coinCounter)
                .AsSingle();
        }

        private void BindCoinsHandler()
        {
            Container.BindInterfacesAndSelfTo<CoinsHandler>()
                .AsSingle();
        }

        private void BindGameplayStateObserver()
        {
            Container.BindInterfacesAndSelfTo<GameplayStateObserver>()
                .AsSingle();   
        }

        private void BindGameOverPopUp()
        {
            Container.Bind<GameOverPopUp>()
                .FromInstance(_gameOverPopUp)
                .AsSingle();
        }
    }
}
