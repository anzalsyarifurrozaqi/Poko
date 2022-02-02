using UnityEngine;

namespace anzal.game
{
    public class ParticleControl : MonoBehaviour
    {
        private ParticleSystem _particleSystem { get { return GetComponent<ParticleSystem>(); } }

        private void OnEnable()
        {            
            Play();
        }       

        private void Play()
        {            
            _particleSystem.Play();
        }        
    }
}