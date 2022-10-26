using UnityEngine;
using UnityEngine.AI;
using StatePattern;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [Header("Settings")]
        public LayerMask playerLayer;
        public float playerSensorRadius;
        public float idleTime;
        public float walkTime;
        public float walkSpeed;

        [Header("Path tracking")]
        public Transform player;


        [Header("Dependencies")]
        public NavMeshAgent navMeshAgent;
        public new Rigidbody rigidbody;


        #region State Machine

        private StateMachine _stateMachine;
        public IdleState idleState;
        public WalkState walkState;
        public ChaseState chaseState;
        public void ChangeState(State state) => _stateMachine.ChangeState(state);

        #endregion


        public bool PlayerDetector => Vector3.Distance(transform.position, player.position) < playerSensorRadius;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();

            idleState = new IdleState(this);
            walkState = new WalkState(this);
            chaseState = new ChaseState(this);

            _stateMachine = new StateMachine(idleState);
        }

        private void Start() => _stateMachine = new StateMachine(idleState);

        private void Update()
        {
            _stateMachine.CurrentState.Update();
            Debug.Log(_stateMachine.CurrentState);
        }

        private void FixedUpdate() => _stateMachine.CurrentState.FixedUpdate();

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, playerSensorRadius);
        }
    }
}
