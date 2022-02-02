using UnityEngine;
using UnityEngine.AI;

namespace anzal.game
{
    public class InitCharacter : CharacterFunction
    {
        private CharacterEquipmentData _EquipmentData => control.DATASET.CHARACTER_EQUIP_DATA;
        public override void RunFunction(CharacterControl control)
        {
            control.characterSetup = control.GetComponentInChildren<CharacterSetup>();
            control.characterUpdateProcessor = control.GetComponentInChildren<CharacterUpdateProcessor>();
            control.characterQueryProcessor = control.GetComponentInChildren<CharacterQueryProcessor>();
            control.aIProgress = control.GetComponentInChildren<AIProgress>();
            control.aiController = control.GetComponentInChildren<AIController>();
            control.navMeshObstacle = control.GetComponent<NavMeshObstacle>();

            if (control.aiController == null)
            {
                if (control.navMeshObstacle != null)
                {
                    control.navMeshObstacle.carving = true;
                }
            }

            if (control.characterSetup.CharacterType == CharacterTypeEnum.PLAYER)
            {
                SetCharacter(control);
            }

            RegisterCharacter();
            InitCharacterStates(control.ANIMATOR);
        }


        void RegisterCharacter()
        {
            if (!CharacterManager.Instance.Characters.Contains(control))
            {
                CharacterManager.Instance.Characters.Add(control);
            }
        }

        void InitCharacterStates(Animator animator)
        {
            CharacterState[] characterStates = animator.GetBehaviours<CharacterState>();

            foreach (CharacterState c in characterStates)
            {
                c.control = control;
            }
        }

        void SetCharacter(CharacterControl control)
        {
            GameObject characterPrefab = _EquipmentData.CharacterPrefab;
            GameObject weapon = _EquipmentData.Weapon;
            GameObject aimObj = Resources.Load("AimObj", typeof(GameObject)) as GameObject;


            control.TargetAimObj = AddEquipment(aimObj);

            if (characterPrefab != null)
            {
                control.Character = AddEquipment(characterPrefab);
            }

            if (weapon != null)
            {
                control.Weapon = AddEquipment(weapon);
            }
        }

        private GameObject AddEquipment(GameObject gameObject)
        {
            GameObject obj = Instantiate(gameObject, control.transform);

            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;

            return obj;
        }
    }
}