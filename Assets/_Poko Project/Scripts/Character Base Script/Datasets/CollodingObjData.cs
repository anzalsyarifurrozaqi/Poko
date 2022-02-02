using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    [System.Serializable]
    public class CollidingObjData
    {
        public Dictionary<TriggerDetector, List<Collider>> CollidingBodyParts = 
        new Dictionary<TriggerDetector, List<Collider>>();
    }
}
