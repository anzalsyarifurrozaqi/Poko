using UnityEngine;

namespace anzal.game
{
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/AI/EnemyMoveForward")]
    public class EnemyMoveForward : CharacterAbility
    {
        public float speed;
        public AnimationCurve SpeedGraph;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {            
        }      

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            RepositionTarget(characterState.control);
            ControlledMove(characterState.control, stateInfo);
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        private void ControlledMove(CharacterControl control, AnimatorStateInfo stateInfo)
        {            
            if (control.aIProgress.pathFindingAgent.Target.DATASET.DEAD_DATA.Dead)
            {                
                return;
            }

            if (!control.aIProgress.pathFindingAgent.StartWalk)
            {
                return;
            }
            else
            {
                control.RunFunction(typeof(MoveTransformForward), speed, SpeedGraph.Evaluate(stateInfo.normalizedTime));
            }            
        }

        private void RepositionTarget(CharacterControl control)
        {
            if (control.aIProgress.TargetMoving())
            {
                control.aIProgress.RepositionPathFinding();
            }
        }
    }
}