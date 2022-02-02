
namespace anzal.game
{
    public class ConditionChecker_EnemyAttackAble : CheckConditionBase
    {
        public override bool MeetCondition(CharacterControl control)
        {
            if (control.DATASET.ENEMY_DATA.closestEnemy.DATASET.ATTACK_DATA.isAttackAble)
            {
                return true;
            }

            return false;
        }
    }
}
