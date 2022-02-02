using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class CurrentAbility : CharacterQuery
    {
        private AbilityData _abilityData => control.DATASET.ABILITY_DATA;
        public override bool ReturnBool(System.Type abilityType)
        {
            if (!abilityType.IsSubclassOf(typeof(CharacterAbility)))
            {
                Debug.LogError(abilityType.ToString() + "is not a character ability");
            }

            foreach(KeyValuePair<CharacterAbility, int> chrAbility in _abilityData.CurrentAbilities)
            {
                if (chrAbility.Key.GetType() == abilityType)
                {
                    return true;
                }
            }

            return false;
        }
    }
}