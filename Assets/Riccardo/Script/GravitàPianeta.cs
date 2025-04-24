using UnityEngine;

public class GravitàPianeta : MonoBehaviour
{
    public float gravitàPianeta = 2f;
    public Transform[] oggettiConGravitàPianeta;

    private void Gravità()
    {
        Vector3 gravitàCustomOggetto = Vector3.zero;
        RaycastHit hit;

        foreach (Transform oggetto in oggettiConGravitàPianeta)
        {
            gravitàCustomOggetto = (oggetto.position - this.transform.position).normalized * gravitàPianeta * Time.fixedDeltaTime;
            if (Physics.Linecast(oggetto.position, gravitàCustomOggetto, out hit))
                oggetto.position = hit.point;
            else
                oggetto.position += gravitàCustomOggetto;
        }
    }

    void FixedUpdate()
    {
        Gravità();
    }
}
