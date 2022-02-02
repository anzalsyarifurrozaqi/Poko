using UnityEngine;

namespace anzal.game
{
    public class InputReader : MonoBehaviour
    {

        float minPhrase = 0.9f;
        
        private MainInput _mainInput;
        private void Awake()
        {
            _mainInput = new MainInput();
        }
        private void OnEnable()
        {
            _mainInput.Enable();
        }

        private void OnDisable()
        {
            _mainInput.Disable();
        }

        public Vector2 ReadMove()
        {            
            return _mainInput.Player.MOVE.ReadValue<Vector2>();
        }
    }

}
