using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

namespace anzal.game
{
    public class CharacterControl : MonoBehaviour
    {
        [Header("Character Equipment")]
        public GameObject Character;
        public GameObject Weapon;
        public GameObject TargetAimObj;

        [Header("Input")]
        public Vector2 Move;
        public bool Attack;

        [Header("Disable Turning")]
        public bool DisableTurning;

        [Header("SubComponens")]
        public CharacterSetup characterSetup;
        public CharacterFunctionProcessor characterFunctionProcessor;
        public CharacterUpdateProcessor characterUpdateProcessor;
        public CharacterQueryProcessor characterQueryProcessor;
        public AIController aiController;
        public AIProgress aIProgress;
        public NavMeshObstacle navMeshObstacle;        
 
        public Datasets DATASET
        {
            get
            {
                if (_characterDatasets == null)
                {
                    _characterDatasets = GetComponent<Datasets>();
                    //_characterDatasets.InitDatasets();
                }

                return _characterDatasets;
            }
        }

        private Datasets _characterDatasets;

        public Rigidbody RIGID_BODY
        {
            get
            {
                if (_rigidBody == null)
                {
                    _rigidBody = GetComponent<Rigidbody>();
                }

                return _rigidBody;
            }
        }

        private Rigidbody _rigidBody;

        public Animator ANIMATOR
        {
            get
            {
                if (_skinnedMeshAnimator == null)
                {
                    _skinnedMeshAnimator = GetComponentInChildren<Animator>();
                }

                return _skinnedMeshAnimator;
            }
        }
        private Animator _skinnedMeshAnimator;

        public BoxCollider BOX_COLLIDER
        {
            get
            {
                if (_rootCollider == null)
                {
                    _rootCollider = GetComponent<BoxCollider>();
                }

                return _rootCollider;
            }
        }
        private BoxCollider _rootCollider;        

        public CharacterUpdate GetUpdater(System.Type UpdaterType)
        {
            if (characterUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))
            {
                return characterUpdateProcessor.DicUpdaters[UpdaterType];
            }
            else
            {
                return null;
            }
        }
        
        public void InitalizeCharacter()
        {
            RunFunction(typeof(InitCharacter), this);

            characterUpdateProcessor.InitUpdaters();
        }

        public void CharacterUpdate()
        {            
            characterUpdateProcessor.RunCharacterUpdate();
        }

        public void CharacterFixedUpdate()
        {
            characterUpdateProcessor.RunCharacterFixedUpdate();
        }
        public void CharacterLateUpdate()
        {
            characterUpdateProcessor.RunCharacterLateUpdate();
        }        

        public bool UpdatingAbility(System.Type abilityType)
        {
            return GetBool(typeof(CurrentAbility), abilityType);
        }

        #region Function
        public void RunFunction(System.Type CharacterFunctionType)
        {
            if (characterFunctionProcessor.DicFunctions.Count > 0)
            {
                characterFunctionProcessor.DicFunctions[CharacterFunctionType].RunFunction();
            }
        }

        public void RunFunction(System.Type CharacterFunctionType, CharacterControl control)
        {
            if (characterFunctionProcessor == null)
            {
                characterFunctionProcessor = GetComponentInChildren<CharacterFunctionProcessor>();
            }

            characterFunctionProcessor.DicFunctions[CharacterFunctionType].RunFunction(control);
        }

        public void RunFunction(System.Type CharacterFunctionType, Vector2 vector21)
        {
            characterFunctionProcessor.DicFunctions[CharacterFunctionType].RunFunction(vector21);
        }

        public void RunFunction(System.Type CharacterFunctionType, float float1)
        {
            characterFunctionProcessor.DicFunctions[CharacterFunctionType].RunFunction(float1);
        }

        public void RunFunction(System.Type CharacterFunctionType, float float1, float float2)
        {
            characterFunctionProcessor.DicFunctions[CharacterFunctionType].RunFunction(float1, float2);
        }

        public void RunFunction(System.Type CharacterFunctionType, GameObject gameObject)
        {
            characterFunctionProcessor.DicFunctions[CharacterFunctionType].RunFunction(gameObject);
        }

        public void RunFunction(System.Type CharacterFunctionType, AttackCondition info)
        {
            characterFunctionProcessor.DicFunctions[CharacterFunctionType].RunFunction(info);
        }

        public void RunFunction(System.Type CharacterFunctionType, CharacterControl Attacker, PoolObjectTypeEnum EffectsType)
        {
            characterFunctionProcessor.DicFunctions[CharacterFunctionType].RunFunction(Attacker, EffectsType);
        }        

        public void RunFunction(System.Type CharacterFunctionType, Collider collider, TriggerDetector triggerDetector)
        {
            characterFunctionProcessor.DicFunctions[CharacterFunctionType].RunFunction(collider, triggerDetector);
        }              

        public void RunFunction(System.Type characterFunctionType, Transform transform1, Transform transform2)
        {
            characterFunctionProcessor.DicFunctions[characterFunctionType].RunFunction(transform1, transform2);
        }

        public void RunFunction(System.Type characterFunctionType, Transform transform1, Vector3 vector31, Quaternion vector32)
        {
            characterFunctionProcessor.DicFunctions[characterFunctionType].RunFunction(transform1, vector31, vector32);
        }        

        public void RunFunction(System.Type characterFunctionType, bool bool1)
        {
            characterFunctionProcessor.DicFunctions[characterFunctionType].RunFunction(bool1);
        }

        public void RunFunction(System.Type characterFunctionType, bool bool1, bool bool2)
        {
            characterFunctionProcessor.DicFunctions[characterFunctionType].RunFunction(bool1, bool2);
        }
        #endregion

        #region Query
        public bool GetBool(System.Type currentAbility, System.Type characterAbility)
        {
            return characterQueryProcessor.DicQueries[currentAbility].ReturnBool(characterAbility);
        }

        public bool GetBool(System.Type CharacterQueryType, AttackCondition info)
        {
            return characterQueryProcessor.DicQueries[CharacterQueryType].ReturnBool(info);
        }

        public bool GetBool(System.Type CharacterQueryType)
        {
            return characterQueryProcessor.DicQueries[CharacterQueryType].ReturnBool();
        }

        public GameObject GetGameObject(System.Type CharacterQueryType, AttackPartTypeEnum str)
        {
            return characterQueryProcessor.DicQueries[CharacterQueryType].ReturnGameObj(str);
        }       
        #endregion
    }
}
