using UnityEngine.Events;

namespace anzal.game
{
    public interface IPauseHandler
    {
        void AddCharacterPausedListener(UnityAction<bool> listener);
    }
}