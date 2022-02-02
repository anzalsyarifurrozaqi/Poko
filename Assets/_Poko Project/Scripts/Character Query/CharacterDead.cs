
namespace anzal.game
{
    public class CharacterDead : CharacterQuery
    {
        private DamageData _damageData => control.DATASET.DAMAGE_DATA;
        public override bool ReturnBool()
        {
            if (_damageData.hp <= 0f)
            {
                return true;
            } else {
                return false;
            }
        }
    }
}