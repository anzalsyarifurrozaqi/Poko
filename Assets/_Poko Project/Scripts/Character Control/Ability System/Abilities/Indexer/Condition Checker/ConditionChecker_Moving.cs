using UnityEngine;

namespace anzal.game
{
    public class ConditionChecker_Moving : CheckConditionBase
    {
        public override bool MeetCondition(CharacterControl control)
        {
            if (control.Move != Vector2.zero)
            {
                return true;
            }

            return false;
        }               
    }
}
