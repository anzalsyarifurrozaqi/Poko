using UnityEngine;

namespace anzal.game
{
    public class Reposition_Spheres_Right : CharacterFunction
    {
        private CollisionSpheresData _collisionSpheresData => control.DATASET.COLLISION_SPHERES_DATA;
        
        public override void RunFunction()
        {
            float right = control.BOX_COLLIDER.bounds.center.x + (control.BOX_COLLIDER.bounds.size.x / 2f);
            float back = control.BOX_COLLIDER.bounds.center.z - (control.BOX_COLLIDER.bounds.size.z / 2f);
            float front = control.BOX_COLLIDER.bounds.center.z + (control.BOX_COLLIDER.bounds.size.z / 2f);
            float y = control.BOX_COLLIDER.bounds.center.y;


            _collisionSpheresData.RightSpheres[0].transform.localPosition = new Vector3(right, y, back) - control.transform.position;
            _collisionSpheresData.RightSpheres[1].transform.localPosition = new Vector3(right, y, front) - control.transform.position;

            float interval = (front - back) / 4;

            for (int i = 2; i < _collisionSpheresData.LeftSpheres.Length; i++)
            {
                _collisionSpheresData.RightSpheres[i].transform.localPosition = new Vector3(right, y, back + (interval * (i - 1))) - control.transform.position;
            }
        }
    }
}