using UnityEngine;

namespace anzal.game
{
    public class ManualInput : CharacterUpdate
    {        
        public override void OnFixedUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void OnLateUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void OnUpdate()
        {                        
            if (InputManager.Instance.Move != Vector2.zero)
            {                
                control.Move = InputManager.Instance.Move;
            }
            else
            {
                control.Move = Vector2.zero;
            }            
        }        
    }
}
