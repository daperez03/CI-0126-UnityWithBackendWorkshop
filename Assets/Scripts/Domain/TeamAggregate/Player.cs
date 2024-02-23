using System;
using UnityWithBackendWorkshop.Domain.Core;
using UnityWithBackendWorkshop.Domain.TeamAggregate;

namespace UnityWithBackendWorkshop.Domain.Entities
{
    public class Player : Entity<UserName>
    {
        public Team? Team { private set; get; }

        public Player(UserName userName) :
            base(userName)
        {
        }

        // For EFCore, do not use.
        private Player()
        {
        }

        public void AssingTeam(Team team)
        {
            if (Team is not null)
            {
                throw new InvalidOperationException("Cannot assing team to a player that is already a member of a team.");
            }
            this.Team = team;
        }

        public void UnassingTeam()
        {
            this.Team = null;
        }
    }
}