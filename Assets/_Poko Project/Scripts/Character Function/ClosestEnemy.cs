
namespace anzal.game
{
    public class ClosestEnemy : CharacterFunction
    {
        private EnemyData _enemyData => control.DATASET.ENEMY_DATA;        
        public override void RunFunction()
        {
            foreach (CharacterControl enemy in _enemyData.visibleEnemys)
            {
                if (enemy == null)
                {
                    continue;
                }

                if (_enemyData.closestEnemy == null)
                {
                    _enemyData.closestEnemy = enemy;                    
                }
                else
                {                    
                    float dist = (enemy.transform.position - control.transform.position).sqrMagnitude;
                    float distToClosesEnemy = (_enemyData.closestEnemy.transform.position - control.transform.position).sqrMagnitude;

                    if (dist < distToClosesEnemy)
                    {
                        _enemyData.closestEnemy = enemy;
                    }
                }
            }
        }
    }
}