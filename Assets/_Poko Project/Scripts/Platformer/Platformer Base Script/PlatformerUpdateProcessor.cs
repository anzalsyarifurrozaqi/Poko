using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class PlatformerUpdateProcessor : MonoBehaviour
    {
        public Dictionary<System.Type, PlatformerUpdate> DicUpdate = new Dictionary<System.Type, PlatformerUpdate>();

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
            Debug.Log("Loading Default Platformer Updates: " + transform.root.gameObject.name);

            SetDefaultUpdate();
        }

        void SetDefaultUpdate()
        {
            AddUpdate(typeof(FallenPlatformer));
        }

        void AddUpdate(System.Type type)
        {
            if (type.IsSubclassOf(typeof(PlatformerUpdate)))
            {
                GameObject obj = new GameObject();
                obj.transform.parent = transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;

                PlatformerUpdate f = obj.AddComponent(type) as PlatformerUpdate;
                DicUpdate.Add(type, f);

                f.PlatformerControl = Platformer;

                obj.name = type.ToString();
                obj.name = obj.name;
            }
        }

        public void RunPlatformerLateUpdate()
        {
            _PlatformerLateUpdate(typeof(FallenPlatformer));
        }

        private void _PlatformerLateUpdate(System.Type type)
        {
            if (DicUpdate.ContainsKey(type))
            {                
                DicUpdate[type].OnLateUpdate();
            }
        }
    }
}