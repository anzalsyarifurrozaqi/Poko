using UnityEngine;

namespace anzal.game
{    
    public class RemovePlatformer : PlatformerFunction
    {        
        public override void RunFunction()
        {            
            var plRigid = PlatformerControl.RIGIDBODY;
            plRigid.isKinematic = false;
            plRigid.AddForce(Vector3.up * 5f, ForceMode.Force);

            PlatformerManager.Instance.RemovePlatformerObj = PlatformerControl;
            PlatformerManager.Instance.ListPlatformer.Remove(PlatformerControl);
        }
    }
}