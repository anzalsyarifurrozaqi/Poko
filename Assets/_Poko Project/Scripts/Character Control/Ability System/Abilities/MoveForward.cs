using UnityEngine;

namespace anzal.game
{
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/CharacterAbilities/MoveForward")]
    public class MoveForward : CharacterAbility
    {
        public float speed;
        public AnimationCurve SpeedGraph;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.control.RunFunction(typeof(FaceForward), characterState.control.Move);
        }       

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ControlledMove(characterState.control, stateInfo);
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        private void ControlledMove(CharacterControl control, AnimatorStateInfo stateInfo)
        {
            if (control.Move == Vector2.zero)
            {
                return;
            } 
            else
            {
                control.RunFunction(typeof(MoveTransformForward), speed, SpeedGraph.Evaluate(stateInfo.normalizedTime));
            }

            checkForward(control);
        }

        private void checkForward(CharacterControl control)
        {
            if (control.Move != Vector2.zero)
            {
                control.RunFunction(typeof(FaceForward), control.Move);
            }
        }
    }
}