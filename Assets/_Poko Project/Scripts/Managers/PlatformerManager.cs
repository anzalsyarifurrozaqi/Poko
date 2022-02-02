using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace anzal.game
{
    public class PlatformerManager : Singleton<PlatformerManager>
    {
        public Vector2 PlatformerIndexPosition;        
        public PlatformerControl NewPlatformerObj = null;
        public PlatformerControl RemovePlatformerObj = null;

        public List<PlatformerControl> ListPlatformer = new List<PlatformerControl>();

        static RemovePlatformerEvent removePlatformerEvent = new RemovePlatformerEvent();

        [SerializeField]
        PlatformerControl[] ArrPlatformers = null;

#region PUBLIC METHOD
#endregion

#region  PRIVATE METHOD
        private void Awake()
        {
            EventManager.Instance.AddRemovePlatformerListener(RemovePlatformer);
        }

        private void LateUpdate()
        {
            InitArayPlatformers();

            for (int i = 0; i < ArrPlatformers.Length; i++)
            {
                ArrPlatformers[i].PlateFormerLateUpdate();
            }
        }

        private void InitArayPlatformers()
        {
            if (ArrPlatformers == null || ArrPlatformers.Length != ListPlatformer.Count)
            {
                ArrPlatformers = new PlatformerControl[ListPlatformer.Count];

                for (int i = 0; i < ListPlatformer.Count; i++)
                {
                    ArrPlatformers[i] = ListPlatformer[i];
                }
            }
        } 
#endregion

#region UTIL METHOD
        void RemovePlatformer()
        {
            PlatformerControl platformer = ListPlatformer[0];

            platformer.RunFunction(typeof(RemovePlatformer));
        }
#endregion        
    }
}