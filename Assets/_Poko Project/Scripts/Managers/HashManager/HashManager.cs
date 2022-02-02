using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class HashManager : Singleton<HashManager>
    {
        HashInitializer hashInitializer = null;
        public void SetupHashInitializer()
        {
            if (hashInitializer == null)
            {
                hashInitializer = Instantiate(
                    Resources.Load("HashInitializer",
                    typeof(HashInitializer)))
                    as HashInitializer;

                hashInitializer.name = typeof(HashInitializer).ToString();
                hashInitializer.transform.position = Vector3.zero;
                hashInitializer.transform.rotation = Quaternion.identity;

                hashInitializer.InitAllHashKeys();
            }
        }

        public int[] ArrMainParams = new int[HashTool.GetLenght(typeof(MainParameterTypeEnum))];
        public int[] ArrAITransition = new int[HashTool.GetLenght(typeof(AITransitionEnum))];


        public Dictionary<HitReactionStatesEnum, int> DicHitReaction = 
             new Dictionary<HitReactionStatesEnum, int>();

        public Dictionary<Wake_Up_States, int> DicWakeUp =
             new Dictionary<Wake_Up_States, int>();


        private void Awake()
        {
            HashTool.AddNameHashToArray(typeof(MainParameterTypeEnum), ArrMainParams);            
            HashTool.AddNameHashToArray(typeof(AITransitionEnum), ArrAITransition);            

            // Hit Reaction States
            HitReactionStatesEnum[] arrHitReaction = System.Enum.GetValues(typeof(HitReactionStatesEnum)) as HitReactionStatesEnum[];

            foreach (HitReactionStatesEnum t in arrHitReaction)
            {
                DicHitReaction.Add(t, Animator.StringToHash(t.ToString()));
            }

            Wake_Up_States[] arrWakeUp = System.Enum.GetValues(typeof(Wake_Up_States)) as Wake_Up_States[];

            foreach(Wake_Up_States t in arrWakeUp)
            {
                DicWakeUp.Add(t, Animator.StringToHash(t.ToString()));
            }
        }
    }
}