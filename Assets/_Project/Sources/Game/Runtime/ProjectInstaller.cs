using UnityEngine;
using Zenject;
using Sources.Services;

namespace Sources.Game.Runtime
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private CurtainView _curtainView;

        public override void InstallBindings()
        {
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