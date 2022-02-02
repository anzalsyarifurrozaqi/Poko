using UnityEngine;

namespace anzal.game
{   
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/CharacterAbilities/CharacterEquipmentShowing")]
    public class CharacterEquipmentShowing : CharacterAbility
    {
        private GameObject smokeEquipmentObj;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.control.RunFunction(typeof(CharacterEquipmentShow), true, true);
            smokeEquipmentObj = ObjectPoolManager.Instance.GetObject(PoolObjectTypeEnum.SMOKE_EQUIPMENT);

            smokeEquipmentObj.transform.position = characterState.control.transform.position + Vector3.up;

            smokeEquipmentObj.SetActive(true);
        }
       
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {            
           
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.control.RunFunction(typeof(CharacterEquipmentShow), false, false);

            smokeEquipmentObj.GetComponent<PoolObject>().TurnOff();
        }
    }
}
