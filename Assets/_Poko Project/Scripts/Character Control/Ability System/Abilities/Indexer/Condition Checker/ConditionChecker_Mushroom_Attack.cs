
namespace anzal.game
{
    public class ConditionChecker_Mushroom_Attack : CheckConditionBase
    {
        public override bool MeetCondition(CharacterControl control)
        {
            float distance = control.aIProgress.AIDistanceToTarget();            
            if (distance < 10f)
            {
                return true;
            }                

            return false;                        
        }                
    }
}
