using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public abstract class CharacterQuery : MonoBehaviour
    {
        public CharacterControl control;

        public virtual bool ReturnBool()
        {
            throw new System.NotImplementedException();
        }
        public virtual bool ReturnBool(System.Type type)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool ReturnBool(AttackCondition attackCondition)
        {
            throw new System.NotImplementedException();
        }

        public virtual GameObject ReturnGameObj(AttackPartTypeEnum attackPartType)
        {
            throw new System.NotImplementedException();
        }
    }

}
