using UnityEngine;

namespace anzal.game
{
    [RequireComponent(typeof(InputReader))]
    public class PlayerInput : MonoBehaviour
    {        
        private InputReader _inputReader;

        private void Awake()
        {
            _inputReader = GetComponent<InputReader>();
        }
        private void Update()
        {            
            InputManager.Instance.Move = _inputReader.ReadMove();
        }
    }
}
