using UnityWithBackendWorkshop.Domain.Entities;
using UnityWithBackendWorkshop.Domain.TeamAggregate;

namespace UnityWithBackendWorkshop.Infrastructure
{
    public partial class PlayerDto
    {
        public Player ToDomain()
        {
            return new Player(
                Domain.TeamAggregate.UserName.Create(UserName));
        }
    }
}