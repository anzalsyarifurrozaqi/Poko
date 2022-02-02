
namespace anzal.game
{
    public class ConditionChecker_Enemydead : CheckConditionBase
    {        
        public override bool MeetCondition(CharacterControl control)
        {
            EnemyData enemyData = control.DATASET.ENEMY_DATA;

            if (enemyData.closestEnemy.DATASET.DEAD_DATA.Dead)
            {
                enemyData.closestEnemy = null;
                enemyData.visibleEnemys.Remove(enemyData.closestEnemy);
                return true;
            }

            return false;
        }
    }
}
