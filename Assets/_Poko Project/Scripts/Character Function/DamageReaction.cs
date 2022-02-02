
namespace anzal.game
{
    public partial class DamageReaction : CharacterFunction
    {
        public override void RunFunction(AttackCondition info)
        {
            if (control.GetBool(typeof(CharacterDead)))
            {
                control.DATASET.RAGDOLL_DATA.IsRagdoll = true;                
            } 
            else 
            {                
                control.RunFunction(typeof(TakeDamage), info);
            }
        }
    }
}
