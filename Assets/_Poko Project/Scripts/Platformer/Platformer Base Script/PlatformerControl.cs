using UnityEngine;

namespace anzal.game
{
    public class PlatformerControl : MonoBehaviour
    {
        [Header("Sub Component")]
        public PlatformerSetup PlatformerSetup;
        public PlatformerFunctionProcessor PlatformerFunctionProcessor;
        public PlatformerQueryProcessor PlatformerQueryProcessor;
        public PlatformerUpdateProcessor PlatformerUpdateProcessor;

        public PlatformerDatasets DATASET
        {
            get
            {
                if (_platformerData == null)
                {
                    _platformerData = GetComponent<PlatformerDatasets>();
                }

                return _platformerData;
            }
        }

        private PlatformerDatasets _platformerData;
        public BoxCollider BOX_COLLIDER
        {
            get
            {
                if (_boxCollider == null)
                {
                    _boxCollider = GetComponent<BoxCollider>();
                }

                return _boxCollider;
            }
        }

        public Rigidbody RIGIDBODY
        {
            get
            {
                if (_rigidbody == null)
                {
                    _rigidbody = GetComponent<Rigidbody>();
                }

                return _rigidbody;
            }
        }

        private Rigidbody _rigidbody;

        private BoxCollider _boxCollider;
        public void InitializePlatformer()
        {
            RunFunction(typeof(InitPlatformer), this);
        }

        public void PlateFormerLateUpdate()
        {            
            PlatformerUpdateProcessor.RunPlatformerLateUpdate();
        }

        #region Function
        public void RunFunction(System.Type PlatformerFunctionType)
        {
            PlatformerFunctionProcessor.DicFunctions[PlatformerFunctionType].RunFunction();
        }

        public void RunFunction(System.Type PlatformerFunctionType, TriggerAreaPositionEnum triggerAreaPosition, PlatformerControl platformer1, PlatformerControl platformer2)
        {
            PlatformerFunctionProcessor.DicFunctions[PlatformerFunctionType].RunFunction(triggerAreaPosition, platformer1, platformer2);
        }        

        public void RunFunction(System.Type PlatformerFunctionType, PlatformerControl platformerControl)
        {
            if (PlatformerFunctionProcessor == null)
            {
                PlatformerFunctionProcessor = GetComponentInChildren<PlatformerFunctionProcessor>();
            }

            PlatformerFunctionProcessor.DicFunctions[PlatformerFunctionType].RunFunction(platformerControl);
        }       

        public void RunFunction(System.Type platformerFunctionType, PlatformerControl platformer1, PlatformerControl platformer2)
        {
            PlatformerFunctionProcessor.DicFunctions[platformerFunctionType].RunFunction(platformer1, platformer2);
        }
        #endregion

        #region Queries
        public PlatformerControl GetPlatformer(System.Type PlatformerQueryType)
        {
            return PlatformerQueryProcessor.DicQueries[PlatformerQueryType].GetPlatformer();
        }
        #endregion        
    }
}