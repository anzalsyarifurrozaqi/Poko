using System.Collections.Generic;

namespace anzal.game
{
    [System.Serializable]
    public class EnemyData
    {
        public List<CharacterControl> visibleEnemys = new List<CharacterControl>();
        public CharacterControl closestEnemy = null;        
    }
}
