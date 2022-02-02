using UnityEngine;

namespace anzal.game
{    
    public class InputManager : Singleton<InputManager>
    {
        public PlayerInput playerInput;
        public Vector2 Move;       

        public void LoadPlayerInput()
        {            
            Object obj = Resources.Load<GameObject>("PlayerInput");
            GameObject p = Instantiate(obj) as GameObject;
            playerInput = p.GetComponent<PlayerInput>();            
        }
       
    }
}