
namespace anzal.game
{
    public class FallenPlatformer : PlatformerUpdate
    {
        public override void OnLateUpdate()
        {
            PlatformerControl removePlatformer = PlatformerManager.Instance.RemovePlatformerObj;
            
            if (removePlatformer == null)
            {
                return;                
            }

            if (removePlatformer.transform.position.y < -5)
            {
                removePlatformer.GetComponent<PoolObject>().TurnOff();
            }  
        }
    }
}