using UnityEngine;

namespace anzal.game
{
    public class AddForceToDamagedPart : CharacterFunction
    {
        public override void RunFunction()
        {
            if (control.DATASET.DAMAGE_DATA.damageTaken != null)
            {
                if (control.DATASET.DAMAGE_DATA.damageTaken.ATTACKER != null)
                {                    
                    ProcAddForce();
                }
            }
        }

        void ProcAddForce()
        {            
            DamageData damageData = control.DATASET.DAMAGE_DATA;

            Vector3 forwardDir = damageData.damageTaken.ATTACKER.transform.forward;
            Vector3 rightDir = damageData.damageTaken.ATTACKER.transform.right;
            Vector3 upDir = damageData.damageTaken.ATTACKER.transform.up;            

            Attack attack = damageData.damageTaken.ATTACK;

            control.RIGID_BODY.AddForce(
                    forwardDir * attack.normalRagdollVelocity.ForwardForce +
                    rightDir * attack.normalRagdollVelocity.RightForce +
                    upDir * attack.normalRagdollVelocity.UpForce
                );                       
        }
    }
}
