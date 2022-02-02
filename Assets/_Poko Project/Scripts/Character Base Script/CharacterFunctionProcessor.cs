using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class CharacterFunctionProcessor : MonoBehaviour
    {
        public Dictionary<System.Type, CharacterFunction> DicFunctions = new Dictionary<System.Type, CharacterFunction>();
        public CharacterFunctionList FunctionListType;

        private void Awake()
        {            
            if (FunctionListType != null)
            {
                List<System.Type> function = FunctionListType.GetList();

                foreach (System.Type t in function)
                {
                    AddFunction(t);
                }
            } else
            {
                Debug.Log("Loading Default Character Function: " + GetComponentInParent<CharacterControl>().name);
                SetDeafaultFunction();
            }

            CharacterControl control = GetComponentInParent<CharacterControl>();
            control.InitalizeCharacter();
        }

        void SetDeafaultFunction()
        {
            AddFunction(typeof(InitCharacter));
            AddFunction(typeof(FaceForward));
            AddFunction(typeof(CheckDownBlocking));
            AddFunction(typeof(MoveTransformForward));
            AddFunction(typeof(Reposition_Spheres_Bottom));
            AddFunction(typeof(Reposition_Spheres_Front));
            AddFunction(typeof(Reposition_Spheres_Back));
            AddFunction(typeof(Reposition_Spheres_Left));
            AddFunction(typeof(Reposition_Spheres_Right));
            AddFunction(typeof(DamageReaction));
            AddFunction(typeof(AddForceToDamagedPart));
            AddFunction(typeof(ClearRagdollVelocity));
            AddFunction(typeof(GetPushedAsRagdool));
            AddFunction(typeof(SpawnHitParticles));            
            AddFunction(typeof(TakeDamage));            
            AddFunction(typeof(FaceEnemy));
            AddFunction(typeof(ClosestEnemy));
            AddFunction(typeof(SpawnProjectile));                              
            AddFunction(typeof(AddHitObject));
            AddFunction(typeof(RemoveHitObj));            
            AddFunction(typeof(CharacterEquipmentShow));
            AddFunction(typeof(WeaponAim));
            AddFunction (typeof(HoverMotion));            
            AddFunction(typeof(FacePlayer));
            AddFunction(typeof(ReInitCharacter));
            AddFunction(typeof(PauseCharacter));
        }

        void AddFunction(System.Type type)
        {
            if (type.IsSubclassOf(typeof(CharacterFunction)))
            {
                GameObject obj = new GameObject();
                obj.transform.parent = this.transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
                
                CharacterFunction f = obj.AddComponent(type) as CharacterFunction;
                DicFunctions.Add(type, f);

                f.control = GetComponentInParent<CharacterControl>();

                obj.name = type.ToString();
                obj.name = obj.name;                
            }
        }
    }

}
