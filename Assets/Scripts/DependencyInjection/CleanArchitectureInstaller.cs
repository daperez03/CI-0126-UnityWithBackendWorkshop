using UnityWithBackendWorkshop.Application;
using UnityWithBackendWorkshop.Infrastructure;
using Zenject;

namespace UnityWithBackendWorkshop.DependencyInjection
{
    public class CleanArchitectureInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InfrastructureLayerInstaller.Install(Container);
            ApplicationLayerInstaller.Install(Container);
        }
    }
}
