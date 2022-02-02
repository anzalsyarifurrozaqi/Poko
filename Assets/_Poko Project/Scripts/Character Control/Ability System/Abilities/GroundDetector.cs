using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/CharacterAbilities/GroundDetector")]
    public class GroundDetector : CharacterAbility
    {

        public float Distance;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }       

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (IsGrounded(characterState.control))
            {
                animator.SetBool(HashManager.Instance.ArrMainParams[(int)MainParameterTypeEnum.Grounded], true);
            } else
            {
                animator.SetBool(HashManager.Instance.ArrMainParams[(int)MainParameterTypeEnum.Grounded], false);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool IsGrounded(CharacterControl control)
        {
            foreach(KeyValuePair<GameObject, List<GameObject>> downBlockingObject in control.DATASET.BLOCKING_OBJ_DATA.DownBlockingObjects)
            {
                GameObject platform = downBlockingObject.Value.Find((obj) => obj.gameObject.layer == LayerMask.NameToLayer(GameLayerEnum.PLATFORMER.ToString()));

                if (platform != null)
                {
                    control.DATASET.GROUND_DATA.GroundObj = platform;
                    control.DATASET.GROUND_DATA.NavMeshPosition = control.DATASET.BLOCKING_OBJ_DATA.ObjDownPoint;

                    return true;
                }
            }

            control.DATASET.GROUND_DATA.GroundObj = null;
            return false;
        }        
    }
}