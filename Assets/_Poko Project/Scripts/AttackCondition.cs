using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class AttackCondition : MonoBehaviour
    {
        public CharacterControl Attacker = null;
        public Attack AttackAbility;
        public List<AttackPartTypeEnum> AttackParts = new List<AttackPartTypeEnum>();
        public bool MustCollide;       
        public int CurrentHits;
        public bool isRegistered;
        public bool  isFinished;
        public bool UseRagdollDeath;
        public List<CharacterControl> RegisteredTargets = new List<CharacterControl>();

        public void ResetInfo(Attack attack, CharacterControl attacker)
        {
            isRegistered = false;
            isFinished = false;
            AttackAbility = attack;
            Attacker = attacker;
            RegisteredTargets.Clear();
        }

        public void Register(Attack attack)
        {
            isRegistered = true;
            AttackAbility = attack;
            AttackParts = attack.AttackPart;
            MustCollide = attack.MustCollide;    
        }

        public void CopyInfo(Attack attack, CharacterControl attacker)
        {
            Attacker = attacker;
            AttackAbility = attack;
            AttackParts = attack.AttackPart;
            MustCollide = attack.MustCollide;
        }

        private void OnDisable()
        {
            isFinished = true;
        }
    }
}

