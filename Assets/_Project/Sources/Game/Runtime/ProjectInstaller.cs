using UnityEngine;
using Zenject;
using Sources.Services;
using Sources.Services.SaveLoad;
using Sources.Services.Score;
using Sources.Services.Master;

namespace Sources.Game.Runtime
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private CurtainView _curtainView;

        public override void InstallBindings()
        {
            Container.Bind<ISaveLoadService>()
                .To<PlayerPrefsSaveLoadService>()
                .AsSingle();

            Container.Bind<IScoreService>()
                .To<ScoreService>()
                .AsSingle();

            Container.Bind<IMasterService>()
                .To<MasterService>()
                .AsSingle();

            Container.Bind<CurtainView>()
                .FromInstance(_curtainView)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<SceneLoader>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<CurtainLoader>()
                .AsSingle();
        }
    }
}