using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityWithBackendWorkshop.Application;
using UnityWithBackendWorkshop.Domain;
using UnityWithBackendWorkshop.Domain.Entities;
using Zenject;

namespace UnityWithBackendWorkshop.Presentation.Teams
{
    public class TeamsManager : MonoBehaviour
    {
        public TeamPresenter teamPrefab;
        public Awaitable GetDataAwaitable { get; private set; }
        public IReadOnlyList<Team> Teams =>
            _teams.AsReadOnly();

        [Inject]
        private readonly ITeamsUseCase _teamsUseCase;
        private List<Team> _teams = new();
        private List<TeamPresenter> _teamGameObjects = new();

        // Start is called before the first frame update
        void Start()
        {
            GetDataAwaitable = GetData();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private async Awaitable GetData()
        {
            // Fetches data.
            _teams = await _teamsUseCase.GetAllTeamsAsync();

            // Cleanup.
            if (_teamGameObjects.Any())
            {
                _teamGameObjects.ForEach(go => Destroy(go));
            }

            // Re-renders objects.
            _teamGameObjects = _teams
                .Select(t =>
                    Instantiate(teamPrefab, transform.position, transform.rotation))
                .ToList();

            StartCoroutine(EsperarUnFrame());
        }
        private IEnumerator EsperarUnFrame()
        {
            // Pausa la ejecución de la corutina por un frame
            yield return null;

            for (int i = 0; i < _teams.Count; ++i)
            {
                Debug.Log("NotifyTeamLoaded");
                _teamsUseCase.NotifyTeamLoaded(_teams[i]);
            }
        }
    }
}
