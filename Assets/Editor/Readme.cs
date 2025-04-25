//Disclamer: questo invece l'ho scritto io :)

using UnityEngine;

[CreateAssetMenu(fileName = "Readme", menuName = "Riccardo/Readme", order = 0)]
public class Readme : ScriptableObject
{
    [TextArea(10, 30)]
    public string testoDiBenvenuto = "" 
        + "Cerchiamo di lavorare tutti in una cartella dedicata per evitare conflitti, tanto questo è solo un progetto per provare. "
        + "Qui sotto ho creato un array di stringhe, chi vuole suggerire un nome per cambiare il nome al progetto lo scriva qui."
        + "(Non so se possa funzionare ... forse no) ";

    [Header("Sondaggio")]
    public string[] cambioNomeProgetto;
}
