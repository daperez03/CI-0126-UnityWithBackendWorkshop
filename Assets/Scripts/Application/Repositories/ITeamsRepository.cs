using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityWithBackendWorkshop.Domain.Core;
using UnityWithBackendWorkshop.Domain.Entities;
using UnityWithBackendWorkshop.Domain.TeamAggregate;

namespace UnityWithBackendWorkshop.Application
{
    public interface ITeamsRepository : IRepository<Team, TeamName>
    {
        public Task<List<Team>> GetAllTeamsAsync();
    }
}
