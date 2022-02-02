using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class IsCollidingWithAttack : CharacterQuery
    {
        public override bool ReturnBool(AttackCondition info)
        {
            foreach (KeyValuePair<TriggerDetector, List<Collider>> data in 
                control.DATASET.COLLIDING_OBJ_DATA.CollidingBodyParts)
            {
                foreach (AttackPartTypeEnum part in info.AttackParts)
                {
                    GameObject attackingPart = info.Attacker.GetGameObject(typeof(GetAttackingPart), part);

                    if (attackingPart != null)
                    {
                        control.DATASET.DAMAGE_DATA.damageTaken = new DamageTaken(
                            info.Attacker,
                            info.AttackAbility,
                            data.Key,
                            attackingPart,
                            Vector3.zero
                        );

                        return true;
                    }
                }
            }            
            return false;
        }
    }
}
