using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class CharacterFunctionList : ScriptableObject
    {
        public List<System.Type> FunctionTypes = new List<System.Type>();

        public virtual List<System.Type> GetList()
        {
            throw new System.NotImplementedException();
        }
    }

}
