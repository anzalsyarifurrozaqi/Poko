using UnityEngine;

namespace anzal.game
{
    public abstract class CharacterFunction : MonoBehaviour
    {
        public CharacterControl control;

        public virtual void RunFunction()
        {
            throw new System.NotImplementedException();
        }        

        public virtual void RunFunction(float float1)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(float float1, float float2)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(Vector2 vector21)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(CharacterControl control)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(GameObject gameObject)
        {
            throw new System.NotImplementedException();
        }    

        public virtual void RunFunction(AttackCondition info)    
        {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(CharacterControl attacker, PoolObjectTypeEnum EffectsType)    
        {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(Collider collider, TriggerDetector triggerDetector)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(Transform transform1, Transform transform)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(Transform transform1, Vector3 vector31, Quaternion quaternion)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(bool bool1)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(bool bool1, bool bool2)
        {
            throw new System.NotImplementedException();
        }
    }
}
