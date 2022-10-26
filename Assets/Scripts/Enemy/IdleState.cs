using UnityEngine;

namespace Enemy
{
    public class IdleState : EnemyState
    {
        public IdleState(EnemyController enemy) : base(enemy) { }

        public override void Start()
        {
            enemy.rigidbody.velocity = Vector3.zero;
            stateTime = Time.time + enemy.idleTime;
        }

        public override void Update()
        {
            if (Time.time >= stateTime)
                enemy.ChangeState(enemy.walkState);
        }

        public override void FixedUpdate()
        {
            if (enemy.PlayerDetector)
                enemy.ChangeState(enemy.chaseState);
        }

        public override string ToString() => nameof(IdleState);
    }
}