using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Squares)), CanEditMultipleObjects]
public class InspectorStuff : Editor {
	public override void OnInspectorGUI()
	{
	    base.OnInspectorGUI();
	    serializedObject.Update();
	    var size = serializedObject.FindProperty("size");
	    if (size.intValue >= 5) {
	    	EditorGUILayout.HelpBox("Please keep Squares to a reasonable size", MessageType.Warning);
	    }
	    EditorGUILayout.BeginHorizontal();
	    if (GUILayout.Button("Select all Squares")) {
	    	var allSquares = Object.FindObjectsByType<Squares>(FindObjectsSortMode.None);
	    	if (allSquares.Length > 0) {
	    		var allSquareObjects = allSquares.Select(square => square.gameObject).ToArray();
	    		Selection.objects = allSquareObjects;
	    	}
	    }
	    if (GUILayout.Button("Clear Selection")) {
	    	Selection.objects = new Object[] {(target as Squares).gameObject};
	    }
	    EditorGUILayout.EndHorizontal();
	    var cachedColor = GUI.backgroundColor;
	    GUI.backgroundColor = Color.green;
	    if (GUILayout.Button("Disable/Enable Squares", GUILayout.Height(40))) {
	    	var allSquares = GameObject.FindObjectsByType<Squares>(FindObjectsInactive.Include, FindObjectsSortMode.None);
	    	foreach (var square in allSquares) {
	    		square.active = !square.active;
	    		square.Refresh();
	    		EditorUtility.SetDirty(square);
	    	}
	    }
	    GUI.backgroundColor = cachedColor;
	}
}
