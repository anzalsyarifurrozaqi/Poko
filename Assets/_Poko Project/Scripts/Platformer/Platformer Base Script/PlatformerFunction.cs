using UnityEngine;

namespace anzal.game
{
    public class PlatformerFunction : MonoBehaviour
    {
        public PlatformerControl PlatformerControl;
        public virtual void RunFunction()
        {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(PlatformerControl platformerControl)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(TriggerAreaPositionEnum triggerAreaPosition, PlatformerControl platformer, PlatformerControl newPlatformer)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(PlatformerControl platformer1, PlatformerControl platformer2)
        {
            throw new System.NotImplementedException();
        }
    }
}
