//Disclamer: non l'ho scritto io, sto ancora cercando di capire come funzioni, ma l'importante è che funziona

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Readme))]
public class ReadmeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Readme readme = (Readme)target;

        GUIStyle boxStyle = new GUIStyle("box");
        boxStyle.padding = new RectOffset(10, 10, 10, 10);
        boxStyle.margin = new RectOffset(0, 0, 10, 10);

        GUIStyle titleStyle = new GUIStyle(EditorStyles.boldLabel);
        titleStyle.fontSize = 16;

        GUIStyle contentStyle = new GUIStyle(EditorStyles.label);
        contentStyle.wordWrap = true;
        contentStyle.richText = true;

        GUILayout.BeginVertical(boxStyle);
        GUILayout.Label("!! README !!", titleStyle);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField(readme.testoDiBenvenuto, contentStyle);
        GUILayout.EndVertical();
    }
}
