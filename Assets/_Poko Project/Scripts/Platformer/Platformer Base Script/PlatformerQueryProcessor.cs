using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class PlatformerQueryProcessor : MonoBehaviour
    {
        public Dictionary<System.Type, PlatformerQuery> DicQueries = new Dictionary<System.Type, PlatformerQuery>();

        public PlatformerControl Platformer
        {
            get
            {
                if (_platformerControl == null)
                {
                    _platformerControl = GetComponentInParent<PlatformerControl>();
                }
                return _platformerControl;
            }
        }

        private void Awake()
        {
            SetDefaultQueries();
        }

        private PlatformerControl _platformerControl = null;
        
        void SetDefaultQueries()
        {
            AddQuery(typeof(AddNewPlatformer));
        }

        void AddQuery(System.Type type)
        {
            if (type.IsSubclassOf(typeof(PlatformerQuery)))
            {
                GameObject obj = new GameObject();
                obj.transform.parent = transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;

                PlatformerQuery f = obj.AddComponent(type) as PlatformerQuery;
                DicQueries.Add(type, f);

                f.Platformer = Platformer;

                obj.name = type.ToString();
                obj.name = obj.name;
            }
        }
    }
}