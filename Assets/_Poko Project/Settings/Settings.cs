using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace anzal.game
{    
    public class Settings : MonoBehaviour
    {
        public Image GameOverPanel;
        public TextMeshProUGUI FPSText;
        public CharacterControl Player;
        private void Awake()
        {            
            GameManager.Instance.Player = Player;
            InputManager.Instance.LoadPlayerInput();
            GameManager.Instance.InitEvent();
            GameManager.Instance.InitPlatformer();
            GameManager.Instance.GameOverPanel = GameOverPanel;            
        }        
    }
}