using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class CharacterUpdateProcessor : MonoBehaviour
    {
        public Dictionary<System.Type, CharacterUpdate> DicUpdaters = new Dictionary<System.Type, CharacterUpdate>();
        public CharacterUpdateList UpdateListType;

        public CharacterControl control
        {
            get
            {
                if (_characterControl == null)
                {
                    _characterControl = GetComponentInParent<CharacterControl>();
                }

                return _characterControl;
            }
        }

        private CharacterControl _characterControl;

        public void InitUpdaters()
        {            
            if (UpdateListType != null)
            {
                Debug.Log(UpdateListType.GetList());
                foreach (System.Type t in UpdateListType.GetList())
                {
                    AddUpdater(t);
                }
            } else 
            {
                Debug.Log("Loading Default Character Updates : " + control.gameObject.name);
                SetDefaultUpdates();
            }

            if (control.characterSetup.CharacterType == CharacterTypeEnum.PLAYER)
            {
                AddUpdater(typeof(ManualInput));
                AddUpdater(typeof(VisibleEnemy));
            }
          
        }

        void SetDefaultUpdates()
        {
            AddUpdater(typeof(BlockingObj));
            AddUpdater(typeof(CollisionSpheres));
            AddUpdater(typeof(BoxColliderUpdater));            
            AddUpdater(typeof(DamageDetector));
            AddUpdater(typeof(Ragdoll));
            AddUpdater(typeof(FallenCharacter));
        }

        void AddUpdater(System.Type UpdaterType)
        {
            if (UpdaterType.IsSubclassOf(typeof(CharacterUpdate)))
            {
                _AddUpdater(UpdaterType);
            }
        }

        void _AddUpdater(System.Type UpdaterType)
        {
            GameObject obj = new GameObject();
            obj.name = UpdaterType.ToString();
            obj.name = obj.name;
            obj.transform.parent = this.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            CharacterUpdate u = obj.AddComponent(UpdaterType) as CharacterUpdate;
            u.control = GetComponentInParent<CharacterControl>();

            DicUpdaters.Add(UpdaterType, u);

            u.InitComponent();            
        }

        public void RunCharacterFixedUpdate()
        {
            CharacterFixedUpdate(typeof(BoxColliderUpdater));
            CharacterFixedUpdate(typeof(BlockingObj));
            CharacterFixedUpdate(typeof(DamageDetector));            
            CharacterFixedUpdate(typeof(VisibleEnemy));
            CharacterFixedUpdate(typeof(FallenCharacter));
        }

        public void RunCharacterUpdate()
        {
            CharacterUpdate(typeof(ManualInput));
            CharacterUpdate(typeof(Ragdoll));
        }

        public void RunCharacterLateUpdate()
        {
            CharacterLateUpdate(typeof(Ragdoll));
        }

        void CharacterUpdate(System.Type UpdaterType)
        {
            
            if (control.characterUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))
            {
                control.characterUpdateProcessor.DicUpdaters[UpdaterType].OnUpdate();
            }
        }

        void CharacterFixedUpdate(System.Type UpdaterType)
        {
            if (control.characterUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))
            {
                control.characterUpdateProcessor.DicUpdaters[UpdaterType].OnFixedUpdate();
            }
        }

        void CharacterLateUpdate(System.Type UpdaterType)
        {
            if (control.characterUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))
            {
                control.characterUpdateProcessor.DicUpdaters[UpdaterType].OnLateUpdate();
            }
        }
    }

}