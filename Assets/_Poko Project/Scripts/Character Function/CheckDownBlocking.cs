using UnityEngine;

namespace anzal.game
{
    public class CheckDownBlocking : CharacterFunction
    {
        public override void RunFunction(float RayDistance)
        {
            foreach (GameObject obj in control.DATASET.COLLISION_SPHERES_DATA.BottomSpheres)
            {
                RaycastHit[] hits;
                hits = Physics.RaycastAll(obj.transform.position, Vector3.down, RayDistance);

                foreach (RaycastHit h in hits)
                {
                    AddObjToDictionary.Add(control.DATASET.BLOCKING_OBJ_DATA.DownBlockingObjects,
                        obj,
                        h.collider.transform.root.gameObject);

                    control.DATASET.BLOCKING_OBJ_DATA.ObjDownPoint = h.point;
                }                
            }
        }
    }
}