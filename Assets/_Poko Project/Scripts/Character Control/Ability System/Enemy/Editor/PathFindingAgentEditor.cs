using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace anzal.game
{
    [CustomEditor(typeof(PathFindingAgent))]
    public class PathFindingAgentEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            PathFindingAgent pathFindingAgent = (PathFindingAgent)target;

            if (GUILayout.Button("Go To Target"))
            {
                pathFindingAgent.GotoTarget();
            }
        }
    }
}
