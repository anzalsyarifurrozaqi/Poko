using UnityEngine;

namespace anzal.game
{
    public class FaceForward : CharacterFunction
    {        
        public override void RunFunction(Vector2 move)
        {
            if (move != Vector2.zero)
            {                
                Vector3 input = new Vector3(-move.y, 0f, move.x);
                Vector3 targetRotation = Quaternion.LookRotation(input).eulerAngles;

                control.transform.rotation = Quaternion.Slerp(
                    transform.rotation, 
                    Quaternion.Euler(targetRotation.x, Mathf.Round(targetRotation.y / 45) * 45, targetRotation.z), 
                    Time.deltaTime * 10f);
            }
        }
    }
}