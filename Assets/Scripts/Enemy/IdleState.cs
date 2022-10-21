using UnityEngine;

namespace Enemy
{
    public class IdleState : EnemyState
    {
        public IdleState(EnemyController enemy) : base(enemy) { }

        public override void Start()
        {
            enemy.rigidbody.velocity = Vector3.zero;
        }
    }
}