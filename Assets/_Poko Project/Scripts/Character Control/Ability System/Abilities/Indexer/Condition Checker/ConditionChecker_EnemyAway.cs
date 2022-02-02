
namespace anzal.game
{
    public class ConditionChecker_EnemyAway : CheckConditionBase
    {        
        public override bool MeetCondition(CharacterControl control)
        {
            EnemyData enemyData = control.DATASET.ENEMY_DATA;
            if (!enemyData.visibleEnemys.Contains(enemyData.closestEnemy))
            {
                enemyData.closestEnemy = null;
                return true;
            }

            return false;
        }
    }
}