using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class GetConditionChecker : MonoBehaviour
    {
        static Dictionary<TransitionConditionTypeEnum, CheckConditionBase> DicCheckers;
        static GameObject condition = null;

        public static CheckConditionBase GET(TransitionConditionTypeEnum conditionType)
        {
            if (DicCheckers == null)
            {
                InitDic();
            }

            return DicCheckers[conditionType];
        }

        public static void InitDic()
        {
            DicCheckers = new Dictionary<TransitionConditionTypeEnum, CheckConditionBase>();

            
            _Add(TransitionConditionTypeEnum.Moving, typeof(ConditionChecker_Moving));
            _Add(TransitionConditionTypeEnum.Atacking, typeof(ConditionChecker_Atacking));
            _Add(TransitionConditionTypeEnum.Enemy_Detected, typeof(ConditionChecker_EnemyDetected));
            _Add(TransitionConditionTypeEnum.Mushroom_Attack, typeof(ConditionChecker_Mushroom_Attack));
            _Add(TransitionConditionTypeEnum.Enemy_Dead, typeof(ConditionChecker_Enemydead));
            _Add(TransitionConditionTypeEnum.Enemy_Away, typeof(ConditionChecker_EnemyAway));
            _Add(TransitionConditionTypeEnum.Enemy_AttackAble, typeof(ConditionChecker_EnemyAttackAble));
            _Add(TransitionConditionTypeEnum.Attack_Condition_Finish, typeof(ConditionCheckker_AttackCondition));
        }

        static void _Add(TransitionConditionTypeEnum transitionConditionType, System.Type checkConditionType)
        {
            if (condition == null)
            {
                condition = new GameObject();
                condition.name = "Condition Checker";
                condition.transform.position = Vector3.zero;
                condition.transform.rotation = Quaternion.identity;
            }

            if (checkConditionType.IsSubclassOf(typeof(CheckConditionBase)))
            {
                GameObject obj = new GameObject();
                obj.transform.parent = condition.transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
                obj.name = checkConditionType.ToString();

                CheckConditionBase c = obj.AddComponent(checkConditionType) as CheckConditionBase;
                
                DicCheckers.Add(transitionConditionType, c);
            }
        }
    }
}
