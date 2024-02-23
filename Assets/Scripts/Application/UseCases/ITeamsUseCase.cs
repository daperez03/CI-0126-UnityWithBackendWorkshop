using System.Collections.Generic;
using System.Threading.Tasks;
using UnityWithBackendWorkshop.Domain.Entities;

namespace UnityWithBackendWorkshop.Application
{
    public interface ITeamsUseCase 
    {
        public Task<List<Team>> GetAllTeamsAsync();
        public void NotifyTeamLoaded(Team team);
    }
}
