//Disclamer: questo invece l'ho scritto io :)

using UnityEngine;

[CreateAssetMenu(fileName = "Readme", menuName = "Riccardo/Readme", order = 0)]
public class Readme : ScriptableObject
{
    [TextArea(10, 30)]
    public string testoDiBenvenuto = "Metto qualcosa di importante da dire qui. " 
        + "Cerchiamo di lavorare tutti in una cartella dedicata per evitare conflitti, tanto questo è solo un progetto per provare.";
}
