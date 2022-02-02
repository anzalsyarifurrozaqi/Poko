using UnityEngine;

namespace anzal.game
{
    public class AIProgress : MonoBehaviour
    {
        public PathFindingAgent pathFindingAgent;
        CharacterControl control;
        private void Awake()
        {
            control = GetComponentInParent<CharacterControl>();
        }

        public float AIDistanceToTarget()
        {
            return Vector3.SqrMagnitude(
                control.aIProgress.pathFindingAgent.Target.transform.position -
                control.transform.position);
        }
        
        public bool TargetMoving()
        {
            if (pathFindingAgent.Target.Move != Vector2.zero)
            {                
                return true;                
            } else {
                return false;
            }
        }

        public void RepositionPathFinding()
        {            
            pathFindingAgent.GotoTarget();
        }
    }
}
