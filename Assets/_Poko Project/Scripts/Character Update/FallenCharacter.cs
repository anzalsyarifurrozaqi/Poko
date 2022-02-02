
namespace anzal.game
{
    public class FallenCharacter : CharacterUpdate
    {
        private RagdoolData _ragdollData => control.DATASET.RAGDOLL_DATA;
        private FallenData _fallenData => control.DATASET.FALLEN_DATA;
        private DeadData _deadData => control.DATASET.DEAD_DATA;
        private DamageData _damageData => control.DATASET.DAMAGE_DATA;
        private PoolObject _poolObject => control.GetComponent<PoolObject>();
        public override void OnFixedUpdate()
        {
            if (_ragdollData.Hip.Transform.position.y < -2f)
            {                
                if (!_fallenData.Fallen)
                {
                    if (_deadData.Dead)
                    {
                        _fallenData.Fallen = true;
                        
                        if (_poolObject != null)
                        {
                            _poolObject.TurnOff();
                        }                        
                    }
                    else
                    {
                        _damageData.hp = 0;                        
                        _ragdollData.IsRagdoll = true;
                    }                    
                }                
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