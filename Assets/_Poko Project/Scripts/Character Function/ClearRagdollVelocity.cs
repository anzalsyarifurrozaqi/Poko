using UnityEngine;

namespace anzal.game
{
    public class ClearRagdollVelocity : CharacterFunction
    {
        private RagdoolData _ragdollData => control.DATASET.RAGDOLL_DATA;
        public override void RunFunction()
        {
            foreach (Muscle bodyPart in _ragdollData.BodyParts)
            {
                bodyPart.Rigidbody.velocity = Vector3.zero;
                bodyPart.Rigidbody.angularVelocity = Vector3.zero;
            }            
        }
    }
}