using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class HashInitializer : MonoBehaviour
    {
        public List<HashClassKey> ListKeys = new List<HashClassKey>();

        public void InitAllHashKeys()
        {
            foreach (HashClassKey k in ListKeys)
            {
                k.ShortNameHash = Animator.StringToHash(k.name);
            }
        }
    }

}