//Disclamer: non l'ho scritto io, sto ancora cercando di capire come funzioni, ma l'importante è che funziona

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Readme))]
public class ReadmeEditor : Editor
{
    SerializedProperty cambioNomeProgetto;

    void OnEnable()
    {
        cambioNomeProgetto = serializedObject.FindProperty("cambioNomeProgetto");
    }

    public override void OnInspectorGUI()
    {
        Readme readme = (Readme)target;
        serializedObject.Update();

        GUIStyle boxStyle = new GUIStyle("box");
        boxStyle.padding = new RectOffset(10, 10, 10, 10);
        boxStyle.margin = new RectOffset(0, 0, 10, 10);

        GUIStyle titleStyle = new GUIStyle(EditorStyles.boldLabel) { fontSize = 16 };
        GUIStyle contentStyle = new GUIStyle(EditorStyles.label)
        {
            wordWrap = true
        };

        GUILayout.BeginVertical(boxStyle);
        GUILayout.Label("README", titleStyle);
        EditorGUILayout.Space();

        // 🧊 Mostra testoDiBenvenuto in sola lettura
        GUILayout.Label("Benvenuto", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox(readme.testoDiBenvenuto, MessageType.Info);

        EditorGUILayout.Space(10);
        GUILayout.Label("Cambio Nome Progetto", EditorStyles.boldLabel);

        // Lista modificabile
        for (int i = 0; i < cambioNomeProgetto.arraySize; i++)
        {
            SerializedProperty item = cambioNomeProgetto.GetArrayElementAtIndex(i);
            EditorGUILayout.BeginHorizontal();
            item.stringValue = EditorGUILayout.TextField($"• Punto {i + 1}", item.stringValue);

            if (GUILayout.Button("−", GUILayout.Width(20)))
            {
                cambioNomeProgetto.DeleteArrayElementAtIndex(i);
                break;
            }
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("+ Aggiungi Punto"))
        {
            cambioNomeProgetto.InsertArrayElementAtIndex(cambioNomeProgetto.arraySize);
            cambioNomeProgetto.GetArrayElementAtIndex(cambioNomeProgetto.arraySize - 1).stringValue = "";
        }

        GUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }
}
