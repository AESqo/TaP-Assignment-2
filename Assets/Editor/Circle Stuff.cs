using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Circles)), CanEditMultipleObjects]
public class CircleStuff : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        var size = serializedObject.FindProperty("size");
        if (size.intValue < 0) {
            EditorGUILayout.HelpBox("Negative Size Values Upset Lorren, so Please Refrain", MessageType.Warning);
        }
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Select all Circles")) {
            var allCircles = Object.FindObjectsByType<Circles>(FindObjectsSortMode.None);
            if (allCircles.Length > 0) {
                var allSquareObjects = allCircles.Select(circle => circle.gameObject).ToArray();
                Selection.objects = allSquareObjects;
            }
        }
        if (GUILayout.Button("Clear Selection")) {
            Selection.objects = new Object[] {(target as Circles).gameObject};
        }
        EditorGUILayout.EndHorizontal();
        var cachedColor = GUI.backgroundColor;
        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Disable/Enable Circles", GUILayout.Height(40))) {
            var allCircles = GameObject.FindObjectsByType<Circles>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            foreach (var circle in allCircles) {
                circle.active = !circle.active;
                circle.Refresh();
                EditorUtility.SetDirty(circle);
            }
        }
        GUI.backgroundColor = cachedColor;
    }
}
