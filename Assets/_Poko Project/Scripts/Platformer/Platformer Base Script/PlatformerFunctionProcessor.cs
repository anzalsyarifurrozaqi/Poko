using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class PlatformerFunctionProcessor : MonoBehaviour
    {
        public Dictionary<System.Type, PlatformerFunction> DicFunctions = new Dictionary<System.Type, PlatformerFunction>();

        public PlatformerControl Platformer
        {
            get
            {
                if (_platformer == null)
                {
                    _platformer = GetComponentInParent<PlatformerControl>();
                }

                return _platformer;
            }
        }

        private PlatformerControl _platformer = null;

        private void Awake()
        {           
            Debug.Log("Loading Default Platformer Function: " + this.transform.root.gameObject.name);
            SetDefaultFunction();

            Platformer.InitializePlatformer();
        }

        void SetDefaultFunction()
        {
            AddFunction(typeof(InitPlatformer));
            AddFunction(typeof(RemovePlatformer));
            AddFunction(typeof(SetPosition));
            AddFunction(typeof(SetOffMeshLink));            
        }

        void AddFunction(System.Type type)
        {
            if (type.IsSubclassOf(typeof(PlatformerFunction)))
            {
                GameObject obj = new GameObject();
                obj.transform.parent = transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;

                PlatformerFunction f = obj.AddComponent(type) as PlatformerFunction;
                DicFunctions.Add(type, f);

                f.PlatformerControl = Platformer;

                obj.name = type.ToString();
                obj.name = obj.name;
            }
        }
    }
}
