using UnityEngine;

namespace anzal.game
{
    public abstract class PlatformerUpdate : MonoBehaviour
    {
        public PlatformerControl PlatformerControl;
        public abstract void OnLateUpdate();        
    }
}