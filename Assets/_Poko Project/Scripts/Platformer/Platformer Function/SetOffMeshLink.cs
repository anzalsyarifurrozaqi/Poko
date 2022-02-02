using UnityEngine.AI;

namespace anzal.game
{
    public class SetOffMeshLink : PlatformerFunction
    {        
        public override void RunFunction(PlatformerControl platformer, PlatformerControl newPlatformer)
        {
            platformer.GetComponentInChildren<OffMeshLink>().startTransform = platformer.DATASET.OBJECT_LINK_DATA.ObjectLink;
            platformer.GetComponentInChildren<OffMeshLink>().endTransform = newPlatformer.DATASET.OBJECT_LINK_DATA.ObjectLink;
        }
    }
}
