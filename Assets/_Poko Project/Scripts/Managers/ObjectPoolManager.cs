using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class ObjectPoolManager : Singleton<ObjectPoolManager>
    {
        public Dictionary<PoolObjectTypeEnum, List<PoolObject>> PoolDictionary = new Dictionary<PoolObjectTypeEnum, List<PoolObject>>();

        private Dictionary<PoolObjectTypeEnum, PoolObject> _firstAvailableDic = new Dictionary<PoolObjectTypeEnum, PoolObject>();

        [SerializeField] private PoolObject firstE;

        private int _initialPool = 1;
        private int _maxPool = 20;
        public void SetUpDictionary()
        {
            PoolObjectTypeEnum[] arr = System.Enum.GetValues(typeof(PoolObjectTypeEnum)) as PoolObjectTypeEnum[];
            
            foreach (PoolObjectTypeEnum p in arr)
            {
                if (!PoolDictionary.ContainsKey(p))
                {
                    PoolDictionary.Add(p, new List<PoolObject>());                    

                    for (int i = 0; i < _initialPool; i++)
                    {
                        Generate(p);
                    }

                    _firstAvailableDic.Add(p, PoolDictionary[p][0]);                    

                    for (int i = 0; i < PoolDictionary[p].Count - 1; i++)
                    {
                        PoolDictionary[p][i].Next = PoolDictionary[p][i + 1];
                    }

                    PoolDictionary[p][PoolDictionary[p].Count - 1].Next = null;
                }
            }
        }

        void Generate(PoolObjectTypeEnum poolObjectType)
        {
            PoolObject obj = PoolObjectLoader.InstantiatePrefab(poolObjectType);

            //obj.transform.parent = ParentObjectManager.Instance.SetParentObject(poolObjectType);
            obj.gameObject.SetActive(false);

            AddObject(obj);
        }


        public void ConfigureDeactivatedObject(PoolObject deactivateObj)
        {            
            deactivateObj.Next = _firstAvailableDic[deactivateObj.PoolObjectType];
            _firstAvailableDic[deactivateObj.PoolObjectType] = deactivateObj;
        }

        public GameObject GetObject(PoolObjectTypeEnum objType)
        {           
            if (PoolDictionary.Count == 0)
            {                
                SetUpDictionary();
            }            

            if (_firstAvailableDic[objType] == null)
            {
                if (PoolDictionary[objType].Count < _maxPool)
                {
                    Generate(objType);

                    PoolObject lastObj = PoolDictionary[objType][PoolDictionary[objType].Count - 1];

                    ConfigureDeactivatedObject(lastObj);
                }
                else
                {
                    return null;
                }               
            }            

            PoolObject newPoolObj = _firstAvailableDic[objType];

            _firstAvailableDic[objType] = newPoolObj.Next;

            firstE = _firstAvailableDic[PoolObjectTypeEnum.ENEMY_MUSHROOM_TYPE_B];

            return newPoolObj.gameObject;
        }

        public void AddObject(PoolObject obj)
        {
            List<PoolObject> list = PoolDictionary[obj.PoolObjectType];
            
            list.Add(obj);
        }
    }
}
