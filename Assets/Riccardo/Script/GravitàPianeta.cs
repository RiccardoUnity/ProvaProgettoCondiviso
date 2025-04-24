using UnityEngine;

public class GravitàPianeta : MonoBehaviour
{
    public float gravitàPianeta = 2f;
    public Transform[] oggettiConGravitàPianeta;
    private float raggioPianeta = 10f;

    private void Gravità()
    {
        Vector3 gravitàCustomOggetto = Vector3.zero;
        RaycastHit hit;
        

        foreach (Transform oggetto in oggettiConGravitàPianeta)
        {
            gravitàCustomOggetto = (oggetto.position - this.transform.position).normalized * gravitàPianeta * Time.fixedDeltaTime * -1f;
            if (Physics.Linecast(oggetto.position, oggetto.position + gravitàCustomOggetto, out hit))
                oggetto.position = hit.point;
            else
                oggetto.position += gravitàCustomOggetto + gravitàCustomOggetto * 0.1f;
        }
    }

    void FixedUpdate()
    {
        Gravità();
    }
}
