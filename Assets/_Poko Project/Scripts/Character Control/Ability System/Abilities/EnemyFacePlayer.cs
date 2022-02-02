using UnityEngine;

namespace anzal.game
{
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/AI/EnemyFacePlayer")]
    public class EnemyFacePlayer : CharacterAbility
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {                       
        }     

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (characterState.control.aIProgress.pathFindingAgent.StartWalk)
            {
                characterState.control.RunFunction(typeof(FacePlayer), characterState.control.aIProgress.pathFindingAgent.gameObject);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
