using StatePattern;

namespace Enemy
{
    public abstract class EnemyState : State
    {
        protected EnemyController enemy;

        protected EnemyState(EnemyController enemy) => this.enemy = enemy;
    }
}