using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class CharacterManager : Singleton<CharacterManager>
    {
        public List<CharacterControl> Characters = new List<CharacterControl>();        

        [SerializeField]
        CharacterControl[] ArrCharacters = null;

#region PULBIC METHOD
        public CharacterControl GetCharacter(GameObject obj)
        {
            for (int i = 0; i < ArrCharacters.Length; i++)
            {
                if (ArrCharacters[i].gameObject == obj)
                {
                    return ArrCharacters[i];
                }
            }

            return null;
        }

        public CharacterControl GetPlayableCharacter()
        {
            foreach (CharacterControl control in Characters)
            {
                if (control.characterUpdateProcessor.DicUpdaters.ContainsKey(typeof(ManualInput)))
                {
                    return control;
                }
            }

            return null;
        }

        public bool IsCharacterPlayable(GameObject characterObj)
        {
            foreach (CharacterControl control in Characters)
            {
                if (control.gameObject == characterObj)
                {
                    if (control.characterUpdateProcessor.DicUpdaters.ContainsKey(typeof(ManualInput)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
#endregion

#region  PRIVATE METHOD
        private void Awake() {
            EventManager.Instance.AddEnemyListener(AddEnemy);
        }
        private void Update()
        {
            InitCharacterArray();

            for (int i = 0; i < ArrCharacters.Length; i++)
            {
                ArrCharacters[i].CharacterUpdate();
            }
        }

        private void FixedUpdate()
        {
            InitCharacterArray();

            for (int i = 0; i < ArrCharacters.Length; i++)
            {
                ArrCharacters[i].CharacterFixedUpdate();
            }
        }

        private void LateUpdate()
        {
            InitCharacterArray();

            for (int i = 0; i < ArrCharacters.Length; i++)
            {
                ArrCharacters[i].CharacterLateUpdate();
            }
        }
#endregion

#region UTIL METHOD
        void InitCharacterArray()
        {            
            if (ArrCharacters == null || ArrCharacters.Length != Characters.Count)
            {
                ArrCharacters = new CharacterControl[Characters.Count];

                for (int i = 0; i < Characters.Count; i++)
                {
                    ArrCharacters[i] = Characters[i];
                }
            }
        }

        void AddEnemy()
        {
            int size = 1;

            StartCoroutine(_AddEnemy(size));
        }

        IEnumerator _AddEnemy(int size)
        {
            yield return new WaitForSeconds(3f);

            for (int i = 0; i < size; i++)
            {                
                GameObject obj = null;

                obj = ObjectPoolManager.Instance.GetObject(PoolObjectTypeEnum.ENEMY_MUSHROOM_TYPE_B);

                obj.SetActive(true);

                float offset = Random.Range(2f, 5f);

                obj.transform.position = PlatformerManager.Instance.NewPlatformerObj.transform.position + Vector3.one * offset;
            }
        }
#endregion
    }
}

