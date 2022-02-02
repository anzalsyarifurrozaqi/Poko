using System.Collections.Generic;

namespace anzal.game
{
    [System.Serializable]
    public class PlatformerTriggerAreaData
    {
        public List<TriggerArea> TriggerAreaList = new List<TriggerArea>();
        public bool IsTriggerAreaActive = false;
    }
}