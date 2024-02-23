using UnityEngine;
using UnityEngine.UI;
using UnityWithBackendWorkshop.Domain;
using UnityWithBackendWorkshop.Domain.TeamAggregate;
using Zenject;

namespace UnityWithBackendWorkshop.Presentation.Teams
{
    public class TeamPresenter : MonoBehaviour
    {
        public Text text;

        [Inject]
        private readonly IEventChannel _eventChannel;

        private TeamName _teamName;
        private int _playerCount;

        // Start is called before the first frame update
        void Start()
        {
            _eventChannel.Subscribe<TeamLoadedEvent>(SetData);

        }

        void OnDestroy()
        {
            if( _eventChannel is not null )
                _eventChannel.Unsubscribe<TeamLoadedEvent>(SetData);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void SetData(TeamLoadedEvent @event)
        {
            _teamName = @event.TeamName;
            _playerCount = @event.PlayerCount;

            RefreshUI();
        }

        private void RefreshUI()
        {
            text.text = $"{_teamName.Value} - Players: {_playerCount}";
        }
    }
}
