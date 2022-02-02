using UnityEngine;

namespace anzal.game
{
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/CharacterAbilities/HoveringMotion")]
    public class HoveringMotion : CharacterAbility
    {
        private Vector3 baseCharacterPosition = Vector3.zero;
        private Quaternion baseCharacterRotation = Quaternion.identity;

        private Vector3 baseWeaponPosition = Vector3.zero;
        private Quaternion baseWeaponRotation = Quaternion.identity;

        private bool _setBaseTransform = false;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            _setBaseTransform = false;
        }        

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (characterState.control.Attack)
            {
                if (!_setBaseTransform)
                {
                    baseCharacterPosition = characterState.control.Character.transform.localPosition;
                    baseCharacterRotation = characterState.control.Character.transform.localRotation;

                    baseWeaponPosition = characterState.control.Weapon.transform.localPosition;
                    baseWeaponRotation = characterState.control.Weapon.transform.localRotation;

                    _setBaseTransform = true;
                }

                characterState.control.RunFunction(typeof(HoverMotion), characterState.control.Character.transform, baseCharacterPosition, baseCharacterRotation);
                characterState.control.RunFunction(typeof(HoverMotion), characterState.control.Weapon.transform, baseWeaponPosition, baseWeaponRotation);
            }            
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.control.Character.transform.localPosition = Vector3.zero;
            characterState.control.Character.transform.localRotation = Quaternion.identity;

            _setBaseTransform = false;
        }
    }
}