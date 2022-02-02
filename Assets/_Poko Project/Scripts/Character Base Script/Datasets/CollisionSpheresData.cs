using UnityEngine;

namespace anzal.game
{
    [System.Serializable]
    public class CollisionSpheresData
    {
        public GameObject[] BottomSpheres = new GameObject[5];
        public GameObject[] FrontSpheres = new GameObject[5];
        public GameObject[] BackSpheres = new GameObject[5];
        public GameObject[] LeftSpheres = new GameObject[5];
        public GameObject[] RightSpheres = new GameObject[5];
    }
}
