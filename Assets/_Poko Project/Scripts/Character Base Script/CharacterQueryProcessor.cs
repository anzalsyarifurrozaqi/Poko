using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class CharacterQueryProcessor : MonoBehaviour
    {
        public Dictionary<System.Type, CharacterQuery> DicQueries = new Dictionary<System.Type, CharacterQuery>();
        public CharacterQueryList QueryListType;

        private void Awake()
        {
            if (QueryListType != null)
            {
                List<System.Type> functions = QueryListType.GetList();

                foreach (System.Type t in functions)
                {
                    AddQuery(t);
                }
            } else
            {
                Debug.Log("Loading Default Character Queries: " + GetComponentInParent<CharacterControl>().name);
                SetDefaultQueries();
            }
        }

        void SetDefaultQueries()
        {
            AddQuery(typeof(CurrentAbility));
            AddQuery(typeof(AttackIsValid));            
            AddQuery(typeof(CharacterDead));
            AddQuery(typeof(GetAttackingPart));
            AddQuery(typeof(IsCollidingWithAttack));                
        }

        void AddQuery(System.Type type)
        {
            if (type.IsSubclassOf(typeof(CharacterQuery)))
            {
                GameObject newQ = new GameObject();
                newQ.transform.parent = this.transform;
                newQ.transform.localPosition = Vector3.zero;
                newQ.transform.localRotation = Quaternion.identity;

                CharacterQuery q = newQ.AddComponent(type) as CharacterQuery;
                DicQueries.Add(type, q);

                q.control = GetComponentInParent<CharacterControl>();

                newQ.name = type.ToString();
                newQ.name = newQ.name;                
            }
        }
    }

}
