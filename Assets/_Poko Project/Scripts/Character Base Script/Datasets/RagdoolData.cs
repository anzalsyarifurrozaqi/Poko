using UnityEngine;
using System.Collections.Generic;

namespace anzal.game
{
    [System.Serializable]
    public class RagdoolData
    {
        public bool IsRagdoll = false;
        public RagdollStateEnum RagdollStateEnum = RagdollStateEnum.Animated;
        public List<Muscle> BodyParts = new List<Muscle>();        
        public Muscle Hip = null;
        public Transform HipParent = null;
    }    

    public class Muscle
    {
        public Transform Transform;
        public Rigidbody Rigidbody;
        public Collider Collider;
        public Vector3 StoredPosition;
        public Quaternion StoredRotation;
        public ConfigurableJoint Joint;
        public TriggerDetector TriggerDetector;

        public Muscle(GameObject obj)
        {
            Transform = obj.GetComponent<Transform>();
            Rigidbody = obj.GetComponent<Rigidbody>();
            Collider = obj.GetComponent<Collider>();
            Joint = obj.GetComponent<ConfigurableJoint>();
            TriggerDetector = obj.GetComponent<TriggerDetector>();            

            if (TriggerDetector == null)
            {
                obj.gameObject.AddComponent<TriggerDetector>();
            }
        }
    }
}
