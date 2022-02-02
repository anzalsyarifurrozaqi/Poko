using UnityEngine;

namespace anzal.game
{    
    public class BlockingObj : CharacterUpdate
    {
        public override void OnFixedUpdate()
        {            
            if (control.RIGID_BODY.velocity.y < 0f)
            {                
                control.RunFunction(typeof(CheckDownBlocking), 0.5f);
            }
        }

        public override void OnLateUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }        
    }
}