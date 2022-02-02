using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    [System.Serializable]
    public class BlockingData
    {
        public Dictionary<GameObject, List<GameObject>> DownBlockingObjects = 
            new Dictionary<GameObject, List<GameObject>>();
        public Vector3 ObjDownPoint;
    }
}
