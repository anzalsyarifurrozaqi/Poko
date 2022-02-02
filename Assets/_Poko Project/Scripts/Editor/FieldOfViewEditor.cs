using UnityEngine;
using UnityEditor;

namespace anzal.game
{
    [CustomEditor (typeof(FieldOfView))]
    public class FieldOfViewEditor : Editor
    {        
        private void OnSceneGUI()
        {
            FieldOfView fieldOfView = (FieldOfView)target;
            Handles.color = Color.white;
            Handles.DrawWireArc(fieldOfView.transform.position, Vector3.up, Vector3.forward, 360, fieldOfView.viewRadius);

            //Vector3 viewAngleA = fieldOfView.DirFromAngle(-fieldOfView.viewAngle / 2, false);
            //Vector3 viewAngleB = fieldOfView.DirFromAngle(fieldOfView.viewAngle / 2, false);

            //Handles.DrawLine(fieldOfView.transform.position, fieldOfView.transform.position + viewAngleA * fieldOfView.viewRadius);
            //Handles.DrawLine(fieldOfView.transform.position, fieldOfView.transform.position + viewAngleB * fieldOfView.viewRadius);

            Handles.color = Color.red;
            foreach (CharacterControl visibleEnemy in fieldOfView.DATASETS.ENEMY_DATA.visibleEnemys)
            {
                Handles.DrawLine(fieldOfView.transform.position, visibleEnemy.transform.position);
            }
        }
    }
}
