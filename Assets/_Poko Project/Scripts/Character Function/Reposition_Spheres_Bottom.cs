using UnityEngine;

namespace anzal.game
{
    public class Reposition_Spheres_Bottom : CharacterFunction
    {
        private CollisionSpheresData _collisionSpheresData => control.DATASET.COLLISION_SPHERES_DATA;
        public override void RunFunction()
        {
            float bottom = control.BOX_COLLIDER.bounds.center.y - (control.BOX_COLLIDER.bounds.size.y / 2f);
            float front = control.BOX_COLLIDER.bounds.center.z + (control.BOX_COLLIDER.bounds.size.z / 2f);
            float back = control.BOX_COLLIDER.bounds.center.z - (control.BOX_COLLIDER.bounds.size.z / 2f);
            float x = control.BOX_COLLIDER.bounds.center.x;

            _collisionSpheresData.BottomSpheres[0].transform.localPosition = new Vector3(x, bottom, back) - control.transform.position;
            _collisionSpheresData.BottomSpheres[1].transform.localPosition = new Vector3(x, bottom, front) - control.transform.position;

            float interval = (front - back) / 4;

            for (int i = 2; i < _collisionSpheresData.BottomSpheres.Length; i++)
            {
                _collisionSpheresData.BottomSpheres[i].transform.localPosition = new Vector3(x, bottom, back + (interval * (i - 1))) - control.transform.position;
            }            
        }
    }
}