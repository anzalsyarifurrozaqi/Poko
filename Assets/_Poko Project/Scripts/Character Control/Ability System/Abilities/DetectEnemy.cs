using UnityEngine;

namespace anzal.game
{
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/CharacterAbilities/DetectEnemy")]
    public class DetectEnemy : CharacterAbility
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (characterState.control.DATASET.ENEMY_DATA.visibleEnemys.Count > 0)
            {
                characterState.control.RunFunction(typeof(ClosestEnemy));
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }        
    }
}