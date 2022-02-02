using UnityEngine;

namespace anzal.game
{
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/CharacterAbilities/UpdateBoxCollider")]
    public class UpdateBoxCollider : CharacterAbility
    {
        public Vector3 TargetCenter;
        public float CenterUpdateSpeed;
        [Space(10)]
        public Vector3 TargetSize;
        public float SizeUpdateSpeed;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.control.DATASET.BOX_COLLIDER_DATA.TargetCenter = TargetCenter;
            characterState.control.DATASET.BOX_COLLIDER_DATA.Center_Update_Speed = CenterUpdateSpeed;
            characterState.control.DATASET.BOX_COLLIDER_DATA.TargetSize = TargetSize;
            characterState.control.DATASET.BOX_COLLIDER_DATA.Size_Update_Speed = SizeUpdateSpeed;

        }       

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}