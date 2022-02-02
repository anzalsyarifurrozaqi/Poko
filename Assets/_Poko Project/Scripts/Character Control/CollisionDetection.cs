using UnityEngine;

namespace anzal.game
{
    public class CollisionDetection : MonoBehaviour
    {
        public static bool IgnoreCollision(CharacterControl control, RaycastHit hit)
        {
            //if (IsBodyPart(control, hit.collider) ||
            //        IsIgnoringCharacter(control, hit.collider))
            //{
            //    return true;
            //}

            return false;
        }

        static bool IsIgnoringCharacter(CharacterControl control, Collider col)
        {
            //if (!control.DATASET.MOVE_DATA.IsIgnoreCharacterTime)
            //{
            //    return false;
            //} else
            //{
            //    CharacterControl blockingChar = CharacterManager.Instance.GetCharacter(col.transform.root.gameObject);

            //    if (blockingChar == null)
            //    {
            //        return false;
            //    }

            //    if (blockingChar == control)
            //    {
            //        return false;
            //    } else
            //    {
            //        return true;
            //    }
            //}

            return false;
        }

        static bool IsBodyPart(CharacterControl control, Collider col)
        {
            if (col.transform.root.gameObject == control.gameObject)
            {
                return true;
            }

            CharacterControl target = CharacterManager.Instance.GetCharacter(col.transform.root.gameObject);

            if (target == null)
            {
                return false;
            }

            return false;
        }
    }

}