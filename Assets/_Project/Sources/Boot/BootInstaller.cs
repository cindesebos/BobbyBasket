using Zenject;

namespace Sources.Boot
{
    public class BootInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BootService>()
                .AsSingle();
        }
    }
}
