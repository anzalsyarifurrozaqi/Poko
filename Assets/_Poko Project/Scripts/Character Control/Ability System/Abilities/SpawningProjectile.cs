using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/CharacterAbilities/SpawningProjectile")]
    public class SpawningProjectile : CharacterAbility
    {    
        public float TimeToSpawn;        
        private List<AttackCondition> _currentAttacks;
        private float _timeSinceSpawn = 0;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            _currentAttacks = AttackManager.Instance.CurrentAttacks;
        }       

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {            
            foreach (AttackCondition attack in _currentAttacks)
            {
                foreach (AttackPartTypeEnum attackPartType in attack.AttackParts)
                {
                    if (attackPartType == AttackPartTypeEnum.PROJECTILE)
                    {
                        _timeSinceSpawn += Time.deltaTime;
                        if (_timeSinceSpawn >= TimeToSpawn && characterState.control.Attack)
                        {                           
                            if (characterState.control.DATASET.ENEMY_DATA.closestEnemy != null)
                            {                                
                                characterState.control.RunFunction(typeof(SpawnProjectile));
                            }

                            _timeSinceSpawn = 0;                            
                        }                        
                    }
                }                
            }            
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}