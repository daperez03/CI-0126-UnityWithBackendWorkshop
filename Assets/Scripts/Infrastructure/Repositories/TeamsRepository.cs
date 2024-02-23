using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityWithBackendWorkshop.Application;
using UnityWithBackendWorkshop.Domain.Core;
using UnityWithBackendWorkshop.Domain.Entities;
using UnityWithBackendWorkshop.Domain.TeamAggregate;

namespace UnityWithBackendWorkshop.Infrastructure.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly ApiClient _apiClient;

        public TeamsRepository(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<Team>> GetAllTeamsAsync()
        {
            var teamsResponse = await _apiClient.TeamsGetAsync();
            var teams = teamsResponse.Teams
                .Select(t => t.ToDomain())
                .ToList();
            return teams;
        }

    }
}
