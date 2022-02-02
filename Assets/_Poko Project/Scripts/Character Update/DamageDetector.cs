using System.Collections.Generic;

namespace anzal.game
{
    public class DamageDetector : CharacterUpdate
    {
        private List<AttackCondition> _currentAttacks;
        public override void InitComponent()
        {
            _currentAttacks = AttackManager.Instance.CurrentAttacks;
        }       

        public override void OnFixedUpdate()
        {                        
            if (_currentAttacks.Count > 0)
            {                
                CheckAttack();
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

        private void CheckAttack()
        {            
            foreach (AttackCondition info in _currentAttacks)
            {
                if (control.GetBool(typeof(AttackIsValid), info))
                {                    
                    if (info.MustCollide)
                    {                        
                        if (control.DATASET.COLLIDING_OBJ_DATA.CollidingBodyParts.Count > 0)
                        {                            
                            if (control.GetBool(typeof(IsCollidingWithAttack), info))
                            {                                
                                control.RunFunction(typeof(DamageReaction), info);
                            }                            
                        }
                    }
                }
            }
        }
    }
}