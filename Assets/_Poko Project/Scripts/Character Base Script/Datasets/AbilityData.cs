using System.Collections.Generic;

namespace anzal.game
{
    [System.Serializable]
    public class AbilityData
    {
        public Dictionary<CharacterAbility, int> CurrentAbilities = 
            new Dictionary<CharacterAbility, int>();
    }
}