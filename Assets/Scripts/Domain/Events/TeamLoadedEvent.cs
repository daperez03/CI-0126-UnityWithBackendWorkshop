using UnityWithBackendWorkshop.Domain;
using UnityWithBackendWorkshop.Domain.TeamAggregate;

public class TeamLoadedEvent : IEvent
{
    public TeamName TeamName { get; }
    public int PlayerCount;
    public TeamLoadedEvent(TeamName teamName, int playerCount)
    {
        TeamName = teamName;
        PlayerCount = playerCount;
    }
}