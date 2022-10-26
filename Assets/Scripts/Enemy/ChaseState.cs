using UnityEngine;

namespace Enemy
{
    public class ChaseState : EnemyState
    {
        public ChaseState(EnemyController enemy) : base(enemy) { }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            enemy.navMeshAgent.destination = enemy.player.position;
        }

        public override void FixedUpdate()
        {
            if (!enemy.PlayerDetector)
                enemy.ChangeState(enemy.idleState);
        }

        public override string ToString() => nameof(ChaseState);
    }
}