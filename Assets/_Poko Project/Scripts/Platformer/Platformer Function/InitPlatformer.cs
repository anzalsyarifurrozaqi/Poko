
namespace anzal.game
{
    public class InitPlatformer : PlatformerFunction
    {                
        public override void RunFunction(PlatformerControl platformer)
        {            
            platformer.PlatformerSetup = platformer.GetComponentInChildren<PlatformerSetup>();
            platformer.PlatformerUpdateProcessor = platformer.GetComponentInChildren<PlatformerUpdateProcessor>();
            platformer.PlatformerQueryProcessor = platformer.GetComponentInChildren<PlatformerQueryProcessor>();
            platformer.PlatformerFunctionProcessor = platformer.GetComponentInChildren<PlatformerFunctionProcessor>();

            PlatformerManager.Instance.NewPlatformerObj = PlatformerControl;

            InitTriggerArea(platformer);
        }

        void InitTriggerArea(PlatformerControl platformerControl)
        {
            TriggerArea[] triggerAreas = platformerControl.GetComponentsInChildren<TriggerArea>();

            foreach (TriggerArea triggerArea in triggerAreas)
            {
                platformerControl.DATASET.PLATFORMER_TRIGGER_DATA.TriggerAreaList.Add(triggerArea);
            }            
        }
    }
}
