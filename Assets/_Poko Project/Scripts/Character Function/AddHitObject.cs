using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class AddHitObject : CharacterFunction
    {
        private CollidingObjData _collidingObjData => control.DATASET.COLLIDING_OBJ_DATA;        
        public override void RunFunction(Collider triggerCollider, TriggerDetector triggerDetector)
        {
            if (!_collidingObjData.CollidingBodyParts.ContainsKey(triggerDetector))
            {
                _collidingObjData.CollidingBodyParts.Add(triggerDetector, new List<Collider>());
            }

            if (!_collidingObjData.CollidingBodyParts[triggerDetector].Contains(triggerCollider))
            {                
                _collidingObjData.CollidingBodyParts[triggerDetector].Add(triggerCollider);
            }
        }      
    }
}