using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(CameraTrigger))]
[ExecuteAlways]
public class CameraTriggerDebugger : Editor
{
    float cameraRange = 1;
    private void OnSceneGUI()
    {
        Handles.color = new Color(1, 0.8f, 0.4f,1);
        GUI.color = new Color(1, 0.8f, 0.4f, 1);

        CameraTrigger cameraTrigger = (CameraTrigger)target;
        Vector3 position = cameraTrigger.transform.position;
        Handles.DrawWireDisc(position ,Vector3.up ,cameraTrigger.switchDistance);

        Handles.Label(position + (cameraRange + 0.5f) * Vector3.right, cameraRange.ToString());

        cameraTrigger.switchDistance = Handles.ScaleValueHandle(
            cameraTrigger.switchDistance,
            position + Vector3.left * cameraTrigger.switchDistance,
            cameraTrigger.transform.rotation,
            1.5f,
            Handles.SphereHandleCap,
            1
            );
    }
}
#endif