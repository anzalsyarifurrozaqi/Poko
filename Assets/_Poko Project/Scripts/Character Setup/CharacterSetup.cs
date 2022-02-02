using UnityEngine;

namespace anzal.game
{
    public class CharacterSetup : MonoBehaviour
    {
        [Space(15)] public CharacterTypeEnum CharacterType;
        [Space(15)] public AttackPartSetup attackPartSetup;
        [Space(15)] public Attack shoot;

        private CharacterControl _control;
        
        private void Awake()
        {
            _control = GetComponentInParent<CharacterControl>();

            SetDamageData();
            EventManager.Instance.addPauseListener(HandlePause);            
        }
        
        void SetDamageData()
        {
            _control.DATASET.DAMAGE_DATA.shoot = shoot;
        }       

        void HandlePause(bool isPause)
        {                        
            _control.RunFunction(typeof(PauseCharacter), isPause);
        }        
    }
}