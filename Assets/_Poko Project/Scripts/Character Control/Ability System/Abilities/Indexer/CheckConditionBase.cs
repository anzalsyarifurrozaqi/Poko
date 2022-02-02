using UnityEngine;

namespace anzal.game
{
    public abstract class CheckConditionBase : MonoBehaviour
    {        
        public abstract bool MeetCondition(CharacterControl control);
    }
}
