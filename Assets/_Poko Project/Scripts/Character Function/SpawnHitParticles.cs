using UnityEngine;

namespace anzal.game
{
    public class SpawnHitParticles : CharacterFunction
    {
        private DamageData _damageData => control.DATASET.DAMAGE_DATA;        
        public override void RunFunction(CharacterControl attacker, PoolObjectTypeEnum EffectsType)
        {
            GameObject smokeHit = ObjectPoolManager.Instance.GetObject(PoolObjectTypeEnum.SMOKE_HIT);
            smokeHit.SetActive(true);

            smokeHit.transform.position = _damageData.damageTaken.DAMAGEE.triggerCollider.bounds.center;
        }
    }
}