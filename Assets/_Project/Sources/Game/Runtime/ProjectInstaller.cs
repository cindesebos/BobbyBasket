using Zenject;
using Sources.Services;

namespace Sources.Game.Runtime
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneLoader>()
                .AsSingle();
        }
    }
}