using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/CharacterAbilities/TransitionIndexer")]
    public class TransitionIndexer : CharacterAbility
    {
        public int Index;
        public List<TransitionConditionTypeEnum> transitionConditions = new List<TransitionConditionTypeEnum>();
        public List<TransitionConditionTypeEnum> not_conditions = new List<TransitionConditionTypeEnum>();

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            

            if (animator.GetInteger(HashManager.Instance.ArrMainParams[(int)MainParameterTypeEnum.TransitionIndex]) == 0)
            {
                if (IndexChecker.MakeTransition(characterState.control, transitionConditions))
                {
                    if (!IndexChecker.NotCondition(characterState.control, not_conditions))
                    {
                        animator.SetInteger(HashManager.Instance.ArrMainParams[(int)MainParameterTypeEnum.TransitionIndex], Index);
                    }
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetInteger(HashManager.Instance.ArrMainParams[(int)MainParameterTypeEnum.TransitionIndex], 0);
        }       
    }
}