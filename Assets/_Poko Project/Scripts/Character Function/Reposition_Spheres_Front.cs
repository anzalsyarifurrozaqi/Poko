using UnityEngine;

namespace anzal.game
{
    public class Reposition_Spheres_Front : CharacterFunction
    {
        private CollisionSpheresData _collisionSpheresData => control.DATASET.COLLISION_SPHERES_DATA;
        public override void RunFunction()
        {            
            float front = control.BOX_COLLIDER.bounds.center.z + (control.BOX_COLLIDER.bounds.size.z / 2f);
            float left = control.BOX_COLLIDER.bounds.center.x - (control.BOX_COLLIDER.bounds.size.x / 2f);
            float right = control.BOX_COLLIDER.bounds.center.x + (control.BOX_COLLIDER.bounds.size.x / 2f);
            float y = control.BOX_COLLIDER.bounds.center.y;


            _collisionSpheresData.FrontSpheres[0].transform.localPosition = new Vector3(left, y, front) - control.transform.position;
            _collisionSpheresData.FrontSpheres[1].transform.localPosition = new Vector3(right, y, front) - control.transform.position;

            float interval = (right - left) / 4;

            for (int i = 2; i < _collisionSpheresData.FrontSpheres.Length; i++)
            {
                _collisionSpheresData.FrontSpheres[i].transform.localPosition = new Vector3(left + (interval * (i - 1)), y, front) - control.transform.position;
            }
        }
    }
}