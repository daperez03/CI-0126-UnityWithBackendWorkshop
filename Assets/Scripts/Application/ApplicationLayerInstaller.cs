using UnityWithBackendWorkshop.Application;
using Zenject;

namespace UnityWithBackendWorkshop.Application
{
    public class ApplicationLayerInstaller : Installer<ApplicationLayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ITeamsUseCase>()
                .To<TeamsUseCase>()
                .AsTransient();
        }
    }
}