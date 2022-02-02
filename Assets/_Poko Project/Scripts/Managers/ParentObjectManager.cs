using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{        
    public class ParentObjectManager : Singleton<ParentObjectManager>
    {
        public Dictionary<PoolObjectTypeEnum, GameObject> DicParentObject = new Dictionary<PoolObjectTypeEnum, GameObject>();        

        public Transform SetParentObject(PoolObjectTypeEnum poolObjectType)
        {
            if (!DicParentObject.ContainsKey(poolObjectType))
            {                
                DicParentObject.Add(poolObjectType, null);
            }
            
            if (DicParentObject[poolObjectType] == null)
            {                
                GameObject gameObject = new GameObject();

                gameObject.gameObject.name = poolObjectType.ToString() + "S";

                gameObject.transform.position = Vector3.zero;
                gameObject.transform.rotation = Quaternion.identity;

                DicParentObject[poolObjectType] = gameObject;                
            }

            return DicParentObject[poolObjectType].transform;
        }
    }    
}
