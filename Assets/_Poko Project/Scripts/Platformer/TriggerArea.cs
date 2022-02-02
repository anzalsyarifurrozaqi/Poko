using UnityEngine;

namespace anzal.game
{    
    public class TriggerArea : MonoBehaviour
    {
        public TriggerAreaPositionEnum TriggerAreaPosition;

        private PlatformerControl _platformer;        
        private PlatformerTriggerAreaData _triggerAreaData => _platformer.DATASET.PLATFORMER_TRIGGER_DATA;        
        private void OnEnable()
        {
            _platformer = GetComponentInParent<PlatformerControl>();
        }        

        private void OnTriggerEnter(Collider col)
        {            
            if (_CheckCharacterTriggered(col))
            {                
                if (!_triggerAreaData.IsTriggerAreaActive)
                {
                    PlatformerControl _newPlatformer = _platformer.GetPlatformer(typeof(AddNewPlatformer));                    

                    _platformer.RunFunction(typeof(SetPosition), TriggerAreaPosition, _platformer, _newPlatformer);
                    _platformer.RunFunction(typeof(SetOffMeshLink), _platformer, _newPlatformer);    

                    PlatformerManager.Instance.NewPlatformerObj = _newPlatformer;
                    
                    GameManager.Instance.AddEnemyInvoker();

                    _triggerAreaData.IsTriggerAreaActive = true;                                                         
                }                
            }
        }

        bool _CheckCharacterTriggered(Collider col)
        {
            if (CharacterManager.Instance.IsCharacterPlayable(col.gameObject))
            {
                return true;
            }

            return false;
        }
    }
}