using UnityEngine;

//Non lo commento ... anche se dovrei ...
public class Lez_Variabili : MonoBehaviour
{
    public enum ShowVar
    {
        None,
        Byte,
        SByte,
        Short,
        UShort,
    }

    public enum DoppioOpe
    {
        IncrementoSuccessivo,
        IncrementoPrecedente,
        DecrementoSuccessivo,
        DecrementoPrecedente,
    }

    public enum Operazione
    {
        Somma,
        Sottrazione,
        Prodotto,
        Divisione,
        Modulo
    }

    public enum TipoVar
    {
        Int,
        Uint,
        Float
    }

    [Header("Serve solo eseguire e cambiare questo campo")]
    public ShowVar showVariabile = ShowVar.None;
    public string stringVariabile;

    private byte _byte;
    private bool _logByte;

    private sbyte _sbyte;
    private bool _logSByte;

    private short _short;
    private bool _logShort;

    private ushort _ushort;
    private bool _logUShort;

    [Header("Scegli l'operazione, inserisci numero di partenza e poi spunta esegui")]
    public DoppioOpe operazione;
    public int numeroPartenza = 10;
    public bool esegui;

    [Header("Calcolatrice")]
    public TipoVar tipoNumero1 = TipoVar.Int;
    public string numero1;
    public Operazione tipoOperazione = Operazione.Somma;
    public TipoVar tipoNumero2 = TipoVar.Int;
    public string numero2;
    public bool calcola;
    private bool _errore;

    private void ShowByte()
    {
        if (!_logByte)
        {
            Debug.Log("Mostro cosa accade se sommo +1 ad una variabile byte");
            _byte = 210;
            _logByte = true;
        }
        
        stringVariabile = (_byte++).ToString();
    }

    private void ShowSByte()
    {
        if (!_logSByte)
        {
            Debug.Log("Mostro cosa accade se sommo +1 ad una variabile sbyte");
            _sbyte = 100;
            _logSByte = true;
        }

        stringVariabile = (_sbyte++).ToString();
    }

    private void ShowShort()
    {
        if (!_logShort)
        {
            Debug.Log("Mostro cosa accade se sommo +1 ad una variabile short prossima al suo limite");
            _short = 32740;
            _logShort = true;
        }

        stringVariabile = (_short++).ToString();
    }
    private void ShowUShort()
    {
        if (!_logUShort)
        {
            Debug.Log("Mostro cosa accade se sommo +1 ad una variabile ushort prossima al suo limite");
            _ushort = 65500;
            _logUShort = true;
        }

        stringVariabile = (_ushort++).ToString();
    }

    private void DoppiaOperazione()
    {
        switch (operazione)
        {
            case DoppioOpe.IncrementoSuccessivo:
                Debug.Log(numeroPartenza++);
                break;
            case DoppioOpe.IncrementoPrecedente:
                Debug.Log(++numeroPartenza);
                break;
            case DoppioOpe.DecrementoSuccessivo:
                Debug.Log(numeroPartenza--);
                break;
            case DoppioOpe.DecrementoPrecedente:
                Debug.Log(--numeroPartenza);
                break;
        }
    }

    private void Calcola()
    {
        int int1 = 0;
        int int2 = 0;
        uint uint1 = 0;
        uint uint2 = 0;
        float float1 = 0;
        float float2 = 0;

        _errore = false;

        switch (tipoNumero1)
        {
            case TipoVar.Int:
                if (!int.TryParse(numero1, out int1))
                {
                    Debug.LogError("Numero1 non è un int valido");
                    _errore = true;
                }
                break;
            case TipoVar.Uint:
                if (!uint.TryParse(numero1, out uint1))
                {
                    Debug.LogError("Numero1 non è un uint valido");
                    _errore = true;
                }
                break;
            case TipoVar.Float:
                if (!float.TryParse(numero1, out float1))
                {
                    Debug.LogError("Numero1 non è un float valido");
                    _errore = true;
                }
                break;
        }

        if (!_errore)
        {
            switch (tipoNumero2)
            {
                case TipoVar.Int:
                    if (int.TryParse(numero2, out int2))
                    {
                        switch (tipoNumero1)
                        {
                            case TipoVar.Int:
                                switch (tipoOperazione)
                                {
                                    case Operazione.Somma:
                                        Debug.Log("Risultato: " + (int1 + int2) + ", Tipo: " + (int1 + int2).GetType());
                                        break;
                                    case Operazione.Sottrazione:
                                        Debug.Log("Risultato: " + (int1 - int2) + ", Tipo: " + (int1 - int2).GetType());
                                        break;
                                    case Operazione.Prodotto:
                                        Debug.Log("Risultato: " + (int1 * int2) + ", Tipo: " + (int1 * int2).GetType());
                                        break;
                                    case Operazione.Divisione:
                                        Debug.Log("Risultato: " + (int1 / int2) + ", Tipo: " + (int1 / int2).GetType());
                                        break;
                                    case Operazione.Modulo:
                                        Debug.Log("Risultato: " + (int1 % int2) + ", Tipo: " + (int1 % int2).GetType());
                                        break;
                                }
                                break;
                            case TipoVar.Uint:
                                switch (tipoOperazione)
                                {
                                    case Operazione.Somma:
                                        Debug.Log("Risultato: " + (uint1 + int2) + ", Tipo: " + (uint1 + int2).GetType());
                                        break;
                                    case Operazione.Sottrazione:
                                        Debug.Log("Risultato: " + (uint1 - int2) + ", Tipo: " + (uint1 - int2).GetType());
                                        break;
                                    case Operazione.Prodotto:
                                        Debug.Log("Risultato: " + (uint1 * int2) + ", Tipo: " + (uint1 * int2).GetType());
                                        break;
                                    case Operazione.Divisione:
                                        Debug.Log("Risultato: " + (uint1 / int2) + ", Tipo: " + (uint1 / int2).GetType());
                                        break;
                                    case Operazione.Modulo:
                                        Debug.Log("Risultato: " + (uint1 % int2) + ", Tipo: " + (uint1 % int2).GetType());
                                        break;
                                }
                                break;
                            case TipoVar.Float:
                                switch (tipoOperazione)
                                {
                                    case Operazione.Somma:
                                        Debug.Log("Risultato: " + (float1 + int2) + ", Tipo: " + (float1 + int2).GetType());
                                        break;
                                    case Operazione.Sottrazione:
                                        Debug.Log("Risultato: " + (float1 - int2) + ", Tipo: " + (float1 - int2).GetType());
                                        break;
                                    case Operazione.Prodotto:
                                        Debug.Log("Risultato: " + (float1 * int2) + ", Tipo: " + (float1 * int2).GetType());
                                        break;
                                    case Operazione.Divisione:
                                        Debug.Log("Risultato: " + (float1 / int2) + ", Tipo: " + (float1 / int2).GetType());
                                        break;
                                    case Operazione.Modulo:
                                        Debug.Log("Risultato: " + (float1 % int2) + ", Tipo: " + (float1 % int2).GetType());
                                        break;
                                }
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("Numero2 non è un int valido");
                    }
                    break;
                case TipoVar.Uint:
                    if (uint.TryParse(numero2, out uint2))
                    {
                        switch (tipoNumero1)
                        {
                            case TipoVar.Int:
                                switch (tipoOperazione)
                                {
                                    case Operazione.Somma:
                                        Debug.Log("Risultato: " + (int1 + uint2) + ", Tipo: " + (int1 + uint2).GetType());
                                        break;
                                    case Operazione.Sottrazione:
                                        Debug.Log("Risultato: " + (int1 - uint2) + ", Tipo: " + (int1 - uint2).GetType());
                                        break;
                                    case Operazione.Prodotto:
                                        Debug.Log("Risultato: " + (int1 * uint2) + ", Tipo: " + (int1 * uint2).GetType());
                                        break;
                                    case Operazione.Divisione:
                                        Debug.Log("Risultato: " + (int1 / uint2) + ", Tipo: " + (int1 / uint2).GetType());
                                        break;
                                    case Operazione.Modulo:
                                        Debug.Log("Risultato: " + (int1 % uint2) + ", Tipo: " + (int1 % uint2).GetType());
                                        break;
                                }
                                break;
                            case TipoVar.Uint:
                                switch (tipoOperazione)
                                {
                                    case Operazione.Somma:
                                        Debug.Log("Risultato: " + (uint1 + uint2) + ", Tipo: " + (uint1 + uint2).GetType());
                                        break;
                                    case Operazione.Sottrazione:
                                        Debug.Log("Risultato: " + (uint1 - uint2) + ", Tipo: " + (uint1 - uint2).GetType());
                                        break;
                                    case Operazione.Prodotto:
                                        Debug.Log("Risultato: " + (uint1 * uint2) + ", Tipo: " + (uint1 * uint2).GetType());
                                        break;
                                    case Operazione.Divisione:
                                        Debug.Log("Risultato: " + (uint1 / uint2) + ", Tipo: " + (uint1 / uint2).GetType());
                                        break;
                                    case Operazione.Modulo:
                                        Debug.Log("Risultato: " + (uint1 % uint2) + ", Tipo: " + (uint1 % uint2).GetType());
                                        break;
                                }
                                break;
                            case TipoVar.Float:
                                switch (tipoOperazione)
                                {
                                    case Operazione.Somma:
                                        Debug.Log("Risultato: " + (float1 + uint2) + ", Tipo: " + (float1 + uint2).GetType());
                                        break;
                                    case Operazione.Sottrazione:
                                        Debug.Log("Risultato: " + (float1 - uint2) + ", Tipo: " + (float1 - uint2).GetType());
                                        break;
                                    case Operazione.Prodotto:
                                        Debug.Log("Risultato: " + (float1 * uint2) + ", Tipo: " + (float1 * uint2).GetType());
                                        break;
                                    case Operazione.Divisione:
                                        Debug.Log("Risultato: " + (float1 / uint2) + ", Tipo: " + (float1 / uint2).GetType());
                                        break;
                                    case Operazione.Modulo:
                                        Debug.Log("Risultato: " + (float1 % uint2) + ", Tipo: " + (float1 % uint2).GetType());
                                        break;
                                }
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("Numero2 non è un uint valido");
                    }
                    break;
                case TipoVar.Float:
                    if (float.TryParse(numero2, out float2))
                    {
                        switch (tipoNumero1)
                        {
                            case TipoVar.Int:
                                switch (tipoOperazione)
                                {
                                    case Operazione.Somma:
                                        Debug.Log("Risultato: " + (int1 + float2) + ", Tipo: " + (int1 + float2).GetType());
                                        break;
                                    case Operazione.Sottrazione:
                                        Debug.Log("Risultato: " + (int1 - float2) + ", Tipo: " + (int1 - float2).GetType());
                                        break;
                                    case Operazione.Prodotto:
                                        Debug.Log("Risultato: " + (int1 * float2) + ", Tipo: " + (int1 * float2).GetType());
                                        break;
                                    case Operazione.Divisione:
                                        Debug.Log("Risultato: " + (int1 / float2) + ", Tipo: " + (int1 / float2).GetType());
                                        break;
                                    case Operazione.Modulo:
                                        Debug.Log("Risultato: " + (int1 % float2) + ", Tipo: " + (int1 % float2).GetType());
                                        break;
                                }
                                break;
                            case TipoVar.Uint:
                                switch (tipoOperazione)
                                {
                                    case Operazione.Somma:
                                        Debug.Log("Risultato: " + (uint1 + float2) + ", Tipo: " + (uint1 + float2).GetType());
                                        break;
                                    case Operazione.Sottrazione:
                                        Debug.Log("Risultato: " + (uint1 - float2) + ", Tipo: " + (uint1 - float2).GetType());
                                        break;
                                    case Operazione.Prodotto:
                                        Debug.Log("Risultato: " + (uint1 * float2) + ", Tipo: " + (uint1 * float2).GetType());
                                        break;
                                    case Operazione.Divisione:
                                        Debug.Log("Risultato: " + (uint1 / float2) + ", Tipo: " + (uint1 / float2).GetType());
                                        break;
                                    case Operazione.Modulo:
                                        Debug.Log("Risultato: " + (uint1 % float2) + ", Tipo: " + (uint1 % float2).GetType());
                                        break;
                                }
                                break;
                            case TipoVar.Float:
                                switch (tipoOperazione)
                                {
                                    case Operazione.Somma:
                                        Debug.Log("Risultato: " + (float1 + float2) + ", Tipo: " + (float1 + float2).GetType());
                                        break;
                                    case Operazione.Sottrazione:
                                        Debug.Log("Risultato: " + (float1 - float2) + ", Tipo: " + (float1 - float2).GetType());
                                        break;
                                    case Operazione.Prodotto:
                                        Debug.Log("Risultato: " + (float1 * float2) + ", Tipo: " + (float1 * float2).GetType());
                                        break;
                                    case Operazione.Divisione:
                                        Debug.Log("Risultato: " + (float1 / float2) + ", Tipo: " + (float1 / float2).GetType());
                                        break;
                                    case Operazione.Modulo:
                                        Debug.Log("Risultato: " + (float1 % float2) + ", Tipo: " + (float1 % float2).GetType());
                                        break;
                                }
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("Numero2 non è un float valido");
                    }
                    break;
            }
        }
    }

    void Start()
    {
        Time.fixedDeltaTime = 0.04f;
    }

    void FixedUpdate()
    {
        if (showVariabile == ShowVar.Byte)
        {
            if (!_logByte)
            {
                _logSByte = false;
                _logShort = false;
                _logUShort = false;
            }
            ShowByte();
        }
        else if (showVariabile == ShowVar.SByte)
        {
            if (!_logSByte)
            {
                _logByte = false;
                _logShort = false;
                _logUShort = false;
            }
            ShowSByte();
        }
        else if (showVariabile == ShowVar.Short) 
        {
            if (!_logShort)
            {
                _logByte = false;
                _logSByte = false;
                _logUShort = false;
            }
            ShowShort();
        }
        else if (showVariabile == ShowVar.UShort)
        {
            if (!_logUShort)
            {
                _logByte = false;
                _logSByte = false;
                _logShort = false;
            }
            ShowUShort();
        }

        if (esegui)
        {
            esegui = false;
            DoppiaOperazione();
        }

        if (calcola)
        {
            calcola = false;
            Calcola();
        }
    }
}
