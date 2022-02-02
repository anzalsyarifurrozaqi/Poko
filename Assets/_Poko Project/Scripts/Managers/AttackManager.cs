using System.Collections.Generic;
using UnityEngine;

namespace anzal.game 
{
    public class AttackManager : Singleton<AttackManager>
    {        
        public List<AttackCondition> CurrentAttacks = new List<AttackCondition>();
        public void ForceDeregister(AttackCondition info)
        {            
            info.isFinished = true;
            info.GetComponent<PoolObject>().TurnOff();
        }
    }
}