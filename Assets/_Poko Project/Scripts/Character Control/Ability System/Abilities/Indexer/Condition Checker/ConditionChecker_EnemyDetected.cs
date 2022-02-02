
namespace anzal.game
{
    public class ConditionChecker_EnemyDetected : CheckConditionBase
    {
        public override bool MeetCondition(CharacterControl control)
        {
            if (control.DATASET.ENEMY_DATA.closestEnemy != null)
            {
                return true;
            }

            return false;
        }
    }
}
