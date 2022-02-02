using UnityEngine;

namespace anzal.game
{
    public class GetAttackingPart : CharacterQuery
    {
        public override GameObject ReturnGameObj(AttackPartTypeEnum attackPartType)
        {
            if (attackPartType == AttackPartTypeEnum.PROJECTILE)
            {
                return control.characterSetup.attackPartSetup.projectile;
            }

            if (attackPartType == AttackPartTypeEnum.MUSHROOM_HEAD)
            {
                return control.characterSetup.attackPartSetup.Head;
            }

            return null;
        }
    }
}