#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Rigidbody2D))]
public class RigidbodyEditor : Editor
{
    void OnSceneGUI()
    {
        Rigidbody2D rb = target as Rigidbody2D;
        if (rb)
        {
            // Uncomment this to show a sphere at the com
            //Handles.color = Color.red;
            //Handles.SphereHandleCap(1, rb.transform.TransformPoint(rb.centerOfMass), Quaternion.identity, 1, EventType.Repaint);
        }
    }
    public override void OnInspectorGUI()
    {
        GUI.skin = EditorGUIUtility.GetBuiltinSkin(UnityEditor.EditorSkin.Inspector);
        DrawDefaultInspector();
    }
}
#endif
