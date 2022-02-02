
namespace anzal.game
{
    public class ConditionChecker_Atacking : CheckConditionBase
    {
        public override bool MeetCondition(CharacterControl control)
        {
            if (control.Attack)
            {
                return true;
            }

            return false;
        }
    }
}
