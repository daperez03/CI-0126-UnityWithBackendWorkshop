using CandyCoded.env;
using NUnit;
using System.Net.Http;
using UnityWithBackendWorkshop.Application;
using UnityWithBackendWorkshop.Domain;
using UnityWithBackendWorkshop.Infrastructure.Repositories;
using Zenject;

namespace UnityWithBackendWorkshop.Infrastructure
{
    public class InfrastructureLayerInstaller : Installer<InfrastructureLayerInstaller>
    {
        public override void InstallBindings()
        {
            env.TryParseEnvironmentVariable("API_BASE_URL", out string apiBaseUrl);
            Container.Bind<ApiClient>()
                .ToSelf()
                .AsTransient()
                .WithArguments(apiBaseUrl, new HttpClient());

            Container.Bind<ITeamsRepository>()
                .To<TeamsRepository>()
                .AsTransient();

            Container.Bind<IEventChannel>()
                .To<SignalsEventChannel>()
                .AsSingle();
            SignalBusInstaller.Install(Container);
            DeclareEvents();
        }

        private void DeclareEvents()
        {
            // Register all events here
            Container.DeclareSignal<TeamLoadedEvent>();
        }
    }
}