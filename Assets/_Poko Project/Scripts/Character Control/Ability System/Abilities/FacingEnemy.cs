using UnityEngine;

namespace anzal.game
{
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/CharacterAbilities/FacingEnemy")]
    public class FacingEnemy : CharacterAbility
    {                   
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {           
        }
      
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (characterState.control.DATASET.ENEMY_DATA.closestEnemy == null) 
            {                
                return;
            }

            characterState.control.RunFunction(typeof(FaceEnemy), characterState.control.DATASET.ENEMY_DATA.closestEnemy.gameObject);                                    
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}