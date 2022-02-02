using UnityEngine;

namespace anzal.game
{
    public class AIController : MonoBehaviour
    {        
        CharacterControl control;
        Animator animatorController;
        private void Awake()
        {
            control = GetComponentInParent<CharacterControl>();
            animatorController = GetComponentInChildren<Animator>();

            CharacterState[] arr = animatorController.GetBehaviours<CharacterState>();

            foreach (CharacterState aiState in arr)
            {
                aiState.control = control;
            }
        }
    }
}
