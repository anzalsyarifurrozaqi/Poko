using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{    
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/CharacterAbilities/Attack")]
    public class Attack : CharacterAbility
    {
        public bool debug;
        public float StartAttackTime;
        public float EndAttackTime;
        public List<AttackPartTypeEnum> AttackPart = new List<AttackPartTypeEnum>();
        public bool MustCollide;                
        public float Damage;

        public NormalRagdollVelocity normalRagdollVelocity;        

        [Header("Death Particles")]
        public bool UseDeathParticles;
        public PoolObjectTypeEnum ParticleType;

        private List<AttackCondition> _currentAttacks;
        private List<AttackCondition> FinishedAttacks = new List<AttackCondition>();

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            _currentAttacks = AttackManager.Instance.CurrentAttacks;
            GameObject obj = ObjectPoolManager.Instance.GetObject(PoolObjectTypeEnum.ATTACK_CONDITION);
            AttackCondition info = obj.GetComponent<AttackCondition>();            

            obj.SetActive(true);
            info.ResetInfo(this, characterState.control);

            if (!_currentAttacks.Contains(info))
            {
                _currentAttacks.Add(info);
            }

            RegisterAttack(characterState, animator, stateInfo);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {           
            
            
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            DeregisterAttack(characterState, animator, stateInfo);
            ClearAttack();
        }        
        
        public void RegisterAttack(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach (AttackCondition info in _currentAttacks)
            {
                if (info == null)
                {
                    continue;
                }

                if (!info.isRegistered && info.AttackAbility == this)
                {
                    if (debug)
                    {
                        Debug.Log(this.name + " registered : ");
                    }
                    info.Register(this);
                }
            }
        }

        public void DeregisterAttack(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach (AttackCondition info in _currentAttacks)
            {
                if (info == null)
                {
                    continue;
                }

                if (info.AttackAbility == this && !info.isFinished)
                {
                    info.isFinished = true;
                    info.GetComponent<PoolObject>().TurnOff();

                    if (debug)
                    {
                        Debug.Log(this.name + " de-registered : ");
                    }
                }
            }
        }

        public void ClearAttack()
        {
            FinishedAttacks.Clear();

            foreach (AttackCondition info in _currentAttacks)
            {
                if (info == null || info.AttackAbility == this /*info.isFinished*/)
                {
                    FinishedAttacks.Add(info);
                }
            }

            foreach (AttackCondition info in FinishedAttacks)
            {
                if (_currentAttacks.Contains(info))
                {
                    _currentAttacks.Remove(info); 
                }
            }
        }
    }
}
