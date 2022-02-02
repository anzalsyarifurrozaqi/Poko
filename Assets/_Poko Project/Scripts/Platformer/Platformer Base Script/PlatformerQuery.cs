using UnityEngine;

namespace anzal.game
{
    public class PlatformerQuery : MonoBehaviour
    {
        public PlatformerControl Platformer;

        public virtual PlatformerControl GetPlatformer()
        {
            throw new System.NotImplementedException();
        }
    }
}