using System.Collections;
using UnityEngine;

namespace anzal.game
{
    public class CharacterEquipmentShow : CharacterFunction
    {        
        private float _moveDuration = 0.5f;
        private float _offset = 1.5f;
               
        public override void RunFunction(bool isUp, bool attack)
        {
            Vector3 targetPosition;
            Vector3 targetScale;
            if (isUp)
            {
                targetPosition = Vector3.up * 2;
                targetScale = Vector3.one;
            }
            else
            {
                targetPosition = Vector3.down;
                targetScale = Vector3.zero;
            }

            StartCoroutine(ShowCharacter(isUp, targetPosition, targetScale, () => control.Attack = attack));            
        }

        private IEnumerator ShowCharacter(bool isUp, Vector3 targetPosition, Vector3 targetScale, System.Action onCompleted)
        {
            float time = 0.0f;
            float offset = Random.Range(-_offset, _offset);
            Vector3 positionOffset = new Vector3(offset, 2f, 0f);


            Vector3 startCharacterPosition = control.Character.transform.localPosition;
            Vector3 startWeaponPosition = control.Weapon.transform.localPosition;

            Vector3 startCharacterScale = control.Character.transform.localScale;
            Vector3 startWeaponScale = control.Weapon.transform.localScale;

            Vector3 tempCharacterTargetPosition = startCharacterPosition + targetPosition;
            Vector3 tempWeaponTargetPosition = startWeaponPosition + targetPosition + positionOffset;

            yield return new WaitForEndOfFrame();

            while (time < _moveDuration)
            {
                control.Character.transform.localPosition = Vector3.Lerp(startCharacterPosition, tempCharacterTargetPosition, time / _moveDuration);
                control.Weapon.transform.localPosition = Vector3.Lerp(startWeaponPosition, tempWeaponTargetPosition, time / _moveDuration);

                control.Character.transform.localScale = Vector3.Lerp(startCharacterScale, targetScale, time / _moveDuration);
                control.Weapon.transform.localScale = Vector3.Lerp(startWeaponScale, targetScale, time / _moveDuration);                                

                time += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            if (isUp)
            {
                control.Character.transform.localPosition = tempCharacterTargetPosition;
                control.Weapon.transform.localPosition = tempWeaponTargetPosition;

                control.Character.transform.localScale = targetScale;
                control.Weapon.transform.localScale = targetScale;
            }
            else
            {
                control.Character.transform.localPosition = Vector3.zero;
                control.Weapon.transform.localPosition = Vector3.zero;

                control.Character.transform.localScale = Vector3.zero;
                control.Weapon.transform.localScale = Vector3.zero;
            }

            onCompleted.Invoke();
            
            control.ANIMATOR.SetBool(HashManager.Instance.ArrMainParams[(int)MainParameterTypeEnum.Attack], control.Attack);
        }
    }    
}