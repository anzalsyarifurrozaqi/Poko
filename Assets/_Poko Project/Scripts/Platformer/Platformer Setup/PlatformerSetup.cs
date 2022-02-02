using UnityEngine;

namespace anzal.game
{
    public class PlatformerSetup : MonoBehaviour
    {
        public PlatformerControl Platformer;
        private void Awake()
        {
            Platformer = GetComponentInParent<PlatformerControl>();                             
        }        
    }
}