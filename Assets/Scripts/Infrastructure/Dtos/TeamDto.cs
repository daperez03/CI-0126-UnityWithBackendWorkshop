using System.Linq;
using UnityWithBackendWorkshop.Domain.Entities;
using UnityWithBackendWorkshop.Domain.TeamAggregate;

namespace UnityWithBackendWorkshop.Infrastructure
{
    public partial class TeamDto
    {
        public Team ToDomain() 
        {
            return new Team(
                Domain.TeamAggregate.TeamName.Create(TeamName),
                Players
                    .Select(p => p.ToDomain())
                    .ToList());
        }
    }
}