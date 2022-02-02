namespace anzal.game
{
    public class BlockedAttack : CharacterQuery
    {
        private DamageData _damageData => control.DATASET.DAMAGE_DATA;

        public override bool ReturnBool(AttackCondition info)
        {
            if (info == _damageData.BlockedAttack &&
                _damageData.BlockedAttack != null)
            {
                return true;
            }

            return false;
        }
    }
}
