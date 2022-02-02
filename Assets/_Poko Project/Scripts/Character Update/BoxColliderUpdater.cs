using UnityEngine;

namespace anzal.game
{
    public class BoxColliderUpdater : CharacterUpdate
    {
        BoxColliderData BOXCOLL_DATA => control.DATASET.BOX_COLLIDER_DATA;

        public override void InitComponent()
        {
            
        }
        public override void OnFixedUpdate()
        {
            BOXCOLL_DATA.IsUpdatingSpheres = false;

            UpdateBoxCollider_Center();
            UpdateBoxCollider_Size();

            if (BOXCOLL_DATA.IsUpdatingSpheres)
            {
                control.RunFunction(typeof(Reposition_Spheres_Bottom));
                control.RunFunction(typeof(Reposition_Spheres_Front));
                control.RunFunction(typeof(Reposition_Spheres_Back));
                control.RunFunction(typeof(Reposition_Spheres_Left));
                control.RunFunction(typeof(Reposition_Spheres_Right));

                if (BOXCOLL_DATA.IsLanding)
                {
                    Debug.Log("Reposition Y");

                    control.RIGID_BODY.MovePosition(new Vector3(
                        this.transform.position.x,
                        BOXCOLL_DATA.LandingPosition.y,
                        this.transform.position.z));
                }
            }
            
        }

        public override void OnLateUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBoxCollider_Size()
        {
            if (!control.UpdatingAbility(typeof(UpdateBoxCollider)))
            {
                return;
            }

            if (Vector3.SqrMagnitude(control.BOX_COLLIDER.size - BOXCOLL_DATA.TargetSize) > 0.00001f)
            {
                control.BOX_COLLIDER.size = Vector3.Lerp(control.BOX_COLLIDER.size,
                    BOXCOLL_DATA.TargetSize,
                    Time.deltaTime * BOXCOLL_DATA.Size_Update_Speed);

                BOXCOLL_DATA.IsUpdatingSpheres = true;
            }
        }

        public void UpdateBoxCollider_Center()
        {
            if (!control.UpdatingAbility(typeof(UpdateBoxCollider)))
            {
                return;
            }

            if (Vector3.SqrMagnitude(control.BOX_COLLIDER.size - BOXCOLL_DATA.TargetCenter) > 0.00001f)
            {
                control.BOX_COLLIDER.center = Vector3.Lerp(control.BOX_COLLIDER.center,
                    BOXCOLL_DATA.TargetCenter,
                    Time.deltaTime * BOXCOLL_DATA.Center_Update_Speed);

                BOXCOLL_DATA.IsUpdatingSpheres = true;
            }
        }
    }
}
