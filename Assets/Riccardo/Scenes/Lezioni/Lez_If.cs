using UnityEngine;

//Anche qui ci vorrebbe un commento ...
public class Lez_If : MonoBehaviour
{
    public enum OperatoreLogico
    {
        AND,
        OR,
        XOR,
    }

    public enum OperatoreConfronto
    {
        UgualeA,
        DiversoDi,
        Minore,
        MinoreUguale,
        Maggiore,
        MaggioreUguale,
    }

    [Header("Operazioni tra operatori logici, premi esegui in esecuzione")]
    public bool a;
    public bool b;
    public OperatoreLogico operatoreLogico;
    [Tooltip("Aggiunge ! prima di A = !A")]
    public bool negazioneA;
    [Tooltip("Aggiunge ! prima di B = !B")]
    public bool negazioneB;
    public bool esegui;

    [Header("Operazioni tra operatori di confronto, premi calcola in esecuzione")]
    public float num1;
    public float num2;
    public OperatoreConfronto confronto;
    public bool calcola;

    private void OperazioneLogica()
    {
        switch (operatoreLogico)
        {
            case OperatoreLogico.AND:
                if (negazioneA && negazioneB)
                {
                    Debug.Log(!a + " && " + !b + " = " + (!a && !b) + ", Tradotto: !a && !b");
                }
                else if (negazioneA)
                {
                    Debug.Log(!a + " && " + b + " = " + (!a && b) + ", Tradotto: !a && b");
                }
                else if (negazioneB)
                {
                    Debug.Log(a + " && " + !b + " = " + (a && !b) + ", Tradotto: a && !b");
                }
                else
                {
                    Debug.Log(a + " && " + b + " = " + (a && b) + ", Tradotto: a && b");
                }
                break;
            case OperatoreLogico.OR:
                if (negazioneA && negazioneB)
                {
                    Debug.Log(!a + " || " + !b + " = " + (!a || !b) + ", Tradotto: !a || !b");
                }
                else if (negazioneA)
                {
                    Debug.Log(!a + " || " + b + " = " + (!a || b) + ", Tradotto: !a || b");
                }
                else if (negazioneB)
                {
                    Debug.Log(a + " || " + !b + " = " + (a || !b) + ", Tradotto: a || !b");
                }
                else
                {
                    Debug.Log(a + " || " + b + " = " + (a || b) + ", Tradotto: a || b");
                }
                break;
            case OperatoreLogico.XOR:
                if (negazioneA && negazioneB)
                {
                    Debug.Log(!a + " ^ " + !b + " = " + (!a ^ !b) + ", Tradotto: !a ^ !b");
                }
                else if (negazioneA)
                {
                    Debug.Log(!a + " ^ " + b + " = " + (!a ^ b) + ", Tradotto: !a ^ b");
                }
                else if (negazioneB)
                {
                    Debug.Log(a + " ^ " + !b + " = " + (a ^ !b) + ", Tradotto: a ^ !b");
                }
                else
                {
                    Debug.Log(a + " ^ " + b + " = " + (a ^ b) + ", Tradotto: a ^ b");
                }
                break;
        }
    }

    private void Calcola()
    {
        switch (confronto)
        {
            case OperatoreConfronto.UgualeA:
                Debug.Log(num1 + " == " + num2 + " = " + (num1 == num2) + ", Tradotto: Num1 == Num2");
                break;
            case OperatoreConfronto.DiversoDi:
                Debug.Log(num1 + " != " + num2 + " = " + (num1 != num2) + ", Tradotto: Num1 != Num2");
                break;
            case OperatoreConfronto.Minore:
                Debug.Log(num1 + " < " + num2 + " = " + (num1 < num2) + ", Tradotto: Num1 < Num2");
                break;
            case OperatoreConfronto.MinoreUguale:
                Debug.Log(num1 + " <= " + num2 + " = " + (num1 <= num2) + ", Tradotto: Num1 <= Num2");
                break;
            case OperatoreConfronto.Maggiore:
                Debug.Log(num1 + " > " + num2 + " = " + (num1 > num2) + ", Tradotto: Num1 > Num2");
                break;
            case OperatoreConfronto.MaggioreUguale:
                Debug.Log(num1 + " >= " + num2 + " = " + (num1 >= num2) + ", Tradotto: Num1 >= Num2");
                break;
        }
    }

    void FixedUpdate()
    {
        if (esegui)
        {
            esegui = false;
            OperazioneLogica();
        }

        if (calcola)
        {
            calcola = false;
            Calcola();
        }
    }
}
