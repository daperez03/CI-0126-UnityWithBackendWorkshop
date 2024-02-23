using System.Collections.Generic;
using System.Threading.Tasks;
using UnityWithBackendWorkshop.Domain;
using UnityWithBackendWorkshop.Domain.Entities;

namespace UnityWithBackendWorkshop.Application
{
    public class TeamsUseCase  : ITeamsUseCase
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly IEventChannel _eventChannel;
        
        public TeamsUseCase(
            ITeamsRepository teamsRepository,
            IEventChannel eventChanell)
        {
            _teamsRepository = teamsRepository;
            _eventChannel = eventChanell;
        }

        public Task<List<Team>> GetAllTeamsAsync() 
        {
            return _teamsRepository.GetAllTeamsAsync();
        }

        public void NotifyTeamLoaded(Team team)
        {
            _eventChannel.Raise(new TeamLoadedEvent(team.Id, team.Players.Count));
        }
    }
}