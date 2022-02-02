using UnityEngine;

namespace anzal.game
{
    public class FacePlayer : CharacterFunction
    {        
        public override void RunFunction(GameObject pathFindingAgentObject)
        {
            if (pathFindingAgentObject != null)
            {
                Vector3 target = pathFindingAgentObject.transform.position - control.transform.position;
                Vector3 targetRotation = Quaternion.LookRotation(target).eulerAngles;

                control.transform.localRotation = Quaternion.Lerp(control.transform.rotation, Quaternion.Euler(0, targetRotation.y, 0), 5f * Time.deltaTime);                
            }
        }
    }
}
