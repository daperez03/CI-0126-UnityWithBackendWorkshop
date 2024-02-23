using FluentAssertions;
using ModestTree.Util;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine.TestTools;
using UnityWithBackendWorkshop.Application;
using UnityWithBackendWorkshop.Domain;
using UnityWithBackendWorkshop.Domain.Entities;
using UnityWithBackendWorkshop.Domain.TeamAggregate;
using UnityWithBackendWorkshop.Presentation.Teams;
using Zenject;

public class TeamsManagerTests : ZenjectIntegrationTestFixture
{
    [UnityTest] 
    public IEnumerator CreatingTeamsManager_LoadsEmptyList_Correctly()
    {
        var teamsUseCaseMock = new Mock<ITeamsUseCase>();
        teamsUseCaseMock
            .Setup(t => t.GetAllTeamsAsync())
            .ReturnsAsync(new List<Team>());

        PreInstall();

        Container.Bind<ITeamsUseCase>()
            .FromInstance(teamsUseCaseMock.Object);
        Container.Bind<TeamsManager>()
            .FromNewComponentOnNewGameObject()
            .AsSingle();

        PostInstall();

        var teamsManager = Container.Resolve<TeamsManager>();
        yield return null;
        yield return teamsManager.GetDataAwaitable;

        teamsManager.Teams.Should().BeEmpty();
    }

    public void NotifyTeamLoaded(Team team) { }

    [UnityTest]
    public IEnumerator CreatingTeamsManager_LoadsSingleElement_Correctly()
    {
        // Nota: trate de arreglarlo a eventos pero no lo logre :(
        var teamsList = new List<Team>()
            {
                new Team(TeamName.Create("team1"))
            };

        var teamsUseCaseMock = new Mock<ITeamsUseCase>();
        teamsUseCaseMock
            .Setup(t => t.GetAllTeamsAsync())
            .ReturnsAsync(teamsList);
        teamsUseCaseMock
            .Setup(t => t.NotifyTeamLoaded(It.IsAny<Team>()));

        PreInstall();
        
        SignalBusInstaller.Install(Container);

        Container.Bind<ITeamsUseCase>()
            .FromInstance(teamsUseCaseMock.Object);

        Container.Bind<IEventChannel>()
                .To<SignalsEventChannel>()
                .AsSingle();
        
        Container.Bind<TeamsManager>()
            .FromNewComponentOnNewGameObject()
            .AsSingle();
        
        Container.Bind<TeamPresenter>()
            .FromNewComponentOnNewGameObject()
            .AsSingle();
        
        Container.DeclareSignal<TeamLoadedEvent>();

        PostInstall();

        var teamPresenter = Container.Resolve<TeamPresenter>();
        var teamsManager = Container.Resolve<TeamsManager>();
        teamsManager.teamPrefab = teamPresenter;
        
        yield return 0;
        // yield return null;
        // yield return teamsManager.GetDataAwaitable;

        // teamsManager.Teams.Should().BeEquivalentTo(teamsList);
    }
}
