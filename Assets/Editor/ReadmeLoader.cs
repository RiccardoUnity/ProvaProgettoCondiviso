//Disclamer: non l'ho scritto io, sto ancora cercando di capire come funzioni, ma l'importante è che funziona

using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class ReadmeLoader
{
    static ReadmeLoader()
    {
        EditorApplication.update += ReadmeInEvidenza;
    }

    private static void ReadmeInEvidenza()
    {
        // Rimuove la callback dopo la prima esecuzione
        EditorApplication.update -= ReadmeInEvidenza;

        // Cerca un asset di tipo "Readme"
        string[] assets = AssetDatabase.FindAssets("t:Readme");
        if (assets.Length == 0) return;

        // Converte il GUID nel path dell'asset
        string path = AssetDatabase.GUIDToAssetPath(assets[0]);

        // Carica l'asset come oggetto Readme
        Object readme = AssetDatabase.LoadAssetAtPath<Readme>(path);

        if (readme != null)
        {
            // Seleziona il Readme nell'Inspector
            Selection.activeObject = readme;

            // Ping visivo nel Project (lo evidenzia)
            EditorGUIUtility.PingObject(readme);
        }
    }
}
