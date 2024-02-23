using System;
using System.Collections.Generic;
using System.Linq;
using UnityWithBackendWorkshop.Domain.Core;
using UnityWithBackendWorkshop.Domain.TeamAggregate;

namespace UnityWithBackendWorkshop.Domain.Entities
{
    public class Team : AggregateRoot<TeamName>
    {
        private readonly List<Player> _players = new();
        public IReadOnlyCollection<Player> Players => _players.AsReadOnly();

        public Team(TeamName name, IEnumerable<Player> players = null)
            : base(name)
        {
            if (players is not null)
            {
                _players = players.ToList();
            }
        }

        // For EFCore, do not use.
        private Team()
        {
        }

        public void AddPlayer(Player player)
        {
            // TODO: Fix when value object and entity equality are implemented. 
            if (_players.Exists(p => p == player))
            {
                throw new InvalidOperationException("Player is alredy on the team");
            }
            _players.Add(player);
            player.AssingTeam(this);
        }

        public void RemovePlayer(UserName playerId)
        {
            var playerToRemove = _players.FirstOrDefault(p => p.Id == playerId);
            if (playerToRemove is null)
            {
                throw new InvalidOperationException("Player isn't on the team");
            }
            _players.Remove(playerToRemove);
            playerToRemove.UnassingTeam();
        }
    }
}