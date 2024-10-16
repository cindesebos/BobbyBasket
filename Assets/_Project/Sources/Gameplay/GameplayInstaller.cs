using UnityEngine;
using Zenject;
using Sources.Gameplay.ItemsBuilder;
using Sources.Gameplay.ItemsBuilder.Factory;
using Sources.UI;
using Sources.Gameplay.Common;
using Sources.Gameplay.Items;

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
        [Space]

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ItemsSFXData _itemsSFXData;

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
            BindItemsSFX();
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

        private void BindItemsSFX()
        {
            Container.Bind<AudioSource>()
                .FromInstance(_audioSource)
                .AsSingle();

            Container.Bind<ItemsSFXData>()
                .FromInstance(_itemsSFXData)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<ItemsSFX>()
                .AsSingle();  
        }
    }
}
