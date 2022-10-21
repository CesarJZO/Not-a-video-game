using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyNavMesh : MonoBehaviour
    {
        [SerializeField] private Transform destination;
        private NavMeshAgent _navMeshAgent;
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            _navMeshAgent.destination = destination.position;
        }
    }
}