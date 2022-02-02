using UnityEngine;

namespace anzal.game
{
    public abstract class CharacterUpdate : MonoBehaviour
    {
        public CharacterControl control;    

        public abstract void OnUpdate();
        public abstract void OnFixedUpdate();
        public abstract void OnLateUpdate();
        public virtual void InitComponent()
        {

        }
    }

}