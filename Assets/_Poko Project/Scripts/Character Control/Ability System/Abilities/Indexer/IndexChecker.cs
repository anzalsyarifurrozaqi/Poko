using System.Collections.Generic;


namespace anzal.game
{
    public class IndexChecker
    {
        public static bool MakeTransition(CharacterControl control, List<TransitionConditionTypeEnum> transitionConditions)
        {
            foreach (TransitionConditionTypeEnum c in transitionConditions)
            {
                CheckConditionBase check = GetConditionChecker.GET(c);

                if (!check.MeetCondition(control))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool NotCondition(CharacterControl control, List<TransitionConditionTypeEnum> transitionConditions)
        {
            foreach (TransitionConditionTypeEnum c in transitionConditions)
            {
                CheckConditionBase check = GetConditionChecker.GET(c);

                if (check.MeetCondition(control))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
