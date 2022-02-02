using UnityEngine;

namespace anzal.game
{
    public class RemoveHitObj : CharacterFunction
    {
        private CollidingObjData _collidingObjData => control.DATASET.COLLIDING_OBJ_DATA;
        public override void RunFunction(Collider triggerCollider, TriggerDetector triggerDetector)
        {
            if (_collidingObjData.CollidingBodyParts.ContainsKey(triggerDetector))
            {
                if (_collidingObjData.CollidingBodyParts[triggerDetector].Contains(triggerCollider))
                {                    
                    _collidingObjData.CollidingBodyParts[triggerDetector].Remove(triggerCollider);
                }

                if (_collidingObjData.CollidingBodyParts[triggerDetector].Count == 0)
                {
                    _collidingObjData.CollidingBodyParts.Remove(triggerDetector);
                }
            }
        }
    }
}