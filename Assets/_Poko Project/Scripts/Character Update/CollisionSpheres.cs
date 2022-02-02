using UnityEngine;

namespace anzal.game
{
    public class CollisionSpheres : CharacterUpdate
    {
        GameObject Bottom = null;
        GameObject Front = null;
        GameObject Back = null;
        GameObject Left = null;
        GameObject Right = null;

        public override void InitComponent()
        {
            if (Bottom == null)
            {
                SetParents();
            }

            SetColliderSpheres();
        }
        public override void OnFixedUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void OnLateUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }

        void SetParents()
        {
            CreateParentObj(ref Bottom, "Bottom");
            CreateParentObj(ref Front, "Front");
            CreateParentObj(ref Back, "Back");
            CreateParentObj(ref Right, "Right");
            CreateParentObj(ref Left, "Left");
        }

        void SetColliderSpheres()
        {
            // bottom

            for (int i = 0; i < 5; i++)
            {
                GameObject obj = LoadCollisionSphereObj();

                control.DATASET.COLLISION_SPHERES_DATA.BottomSpheres[i] = obj;
                obj.transform.parent = Bottom.transform;
            }

            control.RunFunction(typeof(Reposition_Spheres_Bottom));

            // Front

            for (int i = 0; i < 5; i++)
            {
                GameObject obj = LoadCollisionSphereObj();

                control.DATASET.COLLISION_SPHERES_DATA.FrontSpheres[i] = obj;
                obj.transform.parent = Front.transform;
            }

            control.RunFunction(typeof(Reposition_Spheres_Front));
            // Back

            for (int i = 0; i < 5; i++)
            {
                GameObject obj = LoadCollisionSphereObj();

                control.DATASET.COLLISION_SPHERES_DATA.BackSpheres[i] = obj;
                obj.transform.parent = Back.transform;                
            }

            control.RunFunction(typeof(Reposition_Spheres_Back));

            // Left

            for (int i = 0; i < 5; i++)
            {
                GameObject obj = LoadCollisionSphereObj();

                control.DATASET.COLLISION_SPHERES_DATA.LeftSpheres[i] = obj;
                obj.transform.parent = Left.transform;
            }

            control.RunFunction(typeof(Reposition_Spheres_Left));

            // Right

            for (int i = 0; i < 5; i++)
            {
                GameObject obj = LoadCollisionSphereObj();

                control.DATASET.COLLISION_SPHERES_DATA.RightSpheres[i] = obj;
                obj.transform.parent = Right.transform;
            }

            control.RunFunction(typeof(Reposition_Spheres_Right));
        }

        void CreateParentObj(ref GameObject obj, string name)
        {
            obj = new GameObject();
            obj.transform.parent = this.transform;
            obj.name = name;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }

        GameObject LoadCollisionSphereObj()
        {
            return Instantiate(Resources.Load("CollisionSphere", typeof(GameObject)),
                Vector3.zero, Quaternion.identity) as GameObject;
        }
    }
}