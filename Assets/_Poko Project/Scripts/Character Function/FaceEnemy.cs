using UnityEngine;

namespace anzal.game
{
    public class FaceEnemy : CharacterFunction
    {       
        public override void RunFunction(GameObject enemy)
        {
            Vector3 target = enemy.transform.position - control.transform.position;
            Vector3 targetRotation = Quaternion.LookRotation(target).eulerAngles;

            control.transform.localRotation = Quaternion.Lerp(control.transform.rotation, Quaternion.Euler(0, targetRotation.y, 0), 10f * Time.deltaTime);
        }
    }
}
