using UnityEngine;

namespace anzal.game
{
    public class Reposition_Spheres_Back : CharacterFunction
    {
        private CollisionSpheresData _collisionSpheresData => control.DATASET.COLLISION_SPHERES_DATA;
        public override void RunFunction()
        {
            float back = control.BOX_COLLIDER.bounds.center.z - (control.BOX_COLLIDER.bounds.size.z / 2f);
            float left = control.BOX_COLLIDER.bounds.center.x - (control.BOX_COLLIDER.bounds.size.x / 2f);
            float right = control.BOX_COLLIDER.bounds.center.x + (control.BOX_COLLIDER.bounds.size.x / 2f);
            float y = control.BOX_COLLIDER.bounds.center.y;


            _collisionSpheresData.BackSpheres[0].transform.localPosition = new Vector3(left, y, back) - control.transform.position;
            _collisionSpheresData.BackSpheres[1].transform.localPosition = new Vector3(right, y, back) - control.transform.position;

            float interval = (right - left) / 4;

            for (int i = 2; i < _collisionSpheresData.BackSpheres.Length; i++)
            {
                _collisionSpheresData.BackSpheres[i].transform.localPosition = new Vector3(left + (interval * (i - 1)), y, back) - control.transform.position;
            }
        }
    }
}