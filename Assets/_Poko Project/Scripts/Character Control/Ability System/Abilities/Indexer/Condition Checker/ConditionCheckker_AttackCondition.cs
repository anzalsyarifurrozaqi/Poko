
namespace anzal.game
{
    public class ConditionCheckker_AttackCondition : CheckConditionBase
    {
        public override bool MeetCondition(CharacterControl control)
        {
            foreach (AttackCondition info in AttackManager.Instance.CurrentAttacks)
            {
                if (info.Attacker == control)
                {
                    if (info.isFinished)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}