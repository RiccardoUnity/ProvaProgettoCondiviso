using UnityEngine;

public class GravityPlanet : MonoBehaviour
{
    public float gravityPlanet = 0.2f;

    void Start()
    {
        gravityPlanet = Mathf.Abs(gravityPlanet);
    }
}
