using UnityEngine;

namespace anzal.game
{
    public class VisibleEnemy : CharacterUpdate
    {        
        private PlayerVisionData _playerVisionData => control.DATASET.PLAYER_VISION_DATA;
        private EnemyData _enemyData => control.DATASET.ENEMY_DATA;        
        public override void OnFixedUpdate()
        {
            Collider[] arrEnemy = Physics.OverlapSphere(transform.position, _playerVisionData.ViewRadius, _playerVisionData.LayerMaskCharacter);
            
            _InitEnemy(arrEnemy);            
        }

        public override void OnLateUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }

        private void _InitEnemy(Collider[] arrEnemy)
        {            
            if (arrEnemy.Length != _enemyData.visibleEnemys.Count)
            {                
                _enemyData.visibleEnemys.Clear();
                _enemyData.closestEnemy = null;
                for (int i = 0; i < arrEnemy.Length; i++)
                {
                    if (!_enemyData.visibleEnemys.Contains(arrEnemy[i].GetComponentInParent<CharacterControl>()))
                    {
                        _enemyData.visibleEnemys.Add(arrEnemy[i].GetComponentInParent<CharacterControl>());
                    }                    
                }
            }            
        }
    }
}
