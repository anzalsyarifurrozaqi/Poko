using UnityEngine;

namespace anzal.game
{
    public class WeaponAim : CharacterFunction
    {        
        public override void RunFunction(Transform weapon, Transform targetPosition)
        {
            Vector3 target = targetPosition.position - weapon.position;

            Vector3 targetAim = Quaternion.LookRotation(target).eulerAngles;

            weapon.rotation = Quaternion.Lerp(weapon.rotation, Quaternion.Euler(targetAim), 10f * Time.deltaTime);           
        }
    }
}

