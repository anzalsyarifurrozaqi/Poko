using UnityEngine;

namespace anzal.game
{
    public class HashTool : MonoBehaviour
    {
        public static void AddNameHashToArray(System.Type enumType, int[] intArray)
        {
            int count = GetLenght(enumType);

            for (int i = 0; i < count; i++)
            {
                string str = System.Enum.GetName(enumType, i);
                intArray[i] = Animator.StringToHash(str);
            }
        }

        public static int GetLenght(System.Type enumType)
        {
            return System.Enum.GetValues(enumType).Length;
        }
    }

}