using UnityEngine;
namespace Enemy
{
    public class WalkState : EnemyState
    {
        private Vector3 direction;
        public WalkState(EnemyController enemy) : base(enemy) { }
        
        public override void Start()
        {
            direction = new Vector3
            {
                x = Random.Range(-1, 1),
                z = Random.Range(-1, 1)
            }.normalized;
            stateTime = Time.time + enemy.walkTime;
        }

        public override void Update()
        {
            if (Time.time > stateTime)
                enemy.ChangeState(enemy.idleState);
        }

        public override void FixedUpdate()
        {
            enemy.rigidbody.velocity = direction * enemy.walkSpeed;
            if (enemy.PlayerDetector)
                enemy.ChangeState(enemy.chaseState);
        }

        public override string ToString() => nameof(WalkState);
    }
}