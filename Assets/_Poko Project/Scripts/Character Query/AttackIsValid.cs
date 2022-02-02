
namespace anzal.game
{
    public class AttackIsValid : CharacterQuery
    {
        public override bool ReturnBool(AttackCondition info)
        {            
            if (info == null)    
            {                
                return false;
            }

            if (!info.isRegistered)
            {             
                return false;
            }

            if (info.isFinished)
            {               
                return false;
            }          

            if (info.Attacker == control)
            {            
                return false;
            }                        

            if (info.RegisteredTargets.Contains(control))
            {               
                return false;
            }

            if (info.Attacker.gameObject.layer == control.gameObject.layer)
            {
                return false;
            }
            
            return true;
        }
    }
}