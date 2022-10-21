using UnityEngine;
using StatePattern;
namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [Header("Dependencies")]
        public new Rigidbody rigidbody;
        
        #region State Machine

        private StateMachine _stateMachine;
        public IdleState idleState;
        public WalkState walkState;
        public ChaseState chaseState;

        #endregion

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            
            idleState = new IdleState(this);
            walkState = new WalkState(this);
            chaseState = new ChaseState(this);
        }

        private void Start() => _stateMachine = new StateMachine(idleState);

        private void Update() => _stateMachine.CurrentState.Update();

        private void FixedUpdate() => _stateMachine.CurrentState.FixedUpdate();
    }
}
