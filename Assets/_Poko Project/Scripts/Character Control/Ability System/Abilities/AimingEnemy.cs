using UnityEngine;

namespace anzal.game
{
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/CharacterAbilities/AimingEnemy")]
    public class AimingEnemy : CharacterAbility
    {    
        private GameObject _aimObj;
        private GameObject _weaponObj;
        private CharacterControl _closestEnemy;
        
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            _closestEnemy = characterState.control.DATASET.ENEMY_DATA.closestEnemy;
            _aimObj = characterState.control.TargetAimObj;
            _weaponObj = characterState.control.Weapon;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (_closestEnemy ==  null)
            {
                return;
            }
            
            _aimObj.transform.position = _closestEnemy.transform.position;

            characterState.control.RunFunction(typeof(WeaponAim), _weaponObj.transform, _aimObj.transform);
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            _aimObj.transform.localPosition = Vector3.zero;
            characterState.control.DATASET.ENEMY_DATA.closestEnemy = null;
        }              
    }
}