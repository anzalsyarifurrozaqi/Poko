
namespace anzal.game
{
    public class TakeDamage : CharacterFunction
    {
        private RagdoolData _ragdollData => control.DATASET.RAGDOLL_DATA;
        private DamageData _damageData => control.DATASET.DAMAGE_DATA;        
        public override void RunFunction(AttackCondition info)
        {            
            control.RunFunction(typeof(SpawnHitParticles), info.Attacker, info.AttackAbility.ParticleType);

            _damageData.hp -= info.AttackAbility.Damage;
            _ragdollData.IsRagdoll = true;

            AttackManager.Instance.ForceDeregister(info);
        }
    }
}
