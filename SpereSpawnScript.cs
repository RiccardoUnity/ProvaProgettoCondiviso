using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpereSpawnScript : MonoBehaviour
{
    // Creo la mia lista di sfere che popolerò dopo
    List<GameObject> SpereInGame = new List<GameObject>();

    //Creo la variabile pubblica che indica quante sfere voglio creare

    public int numerosfere = 10;

    //Scelgo una distanza minima per le sfere sull'asse x

    private float distanzasfere = 1;

    // Creo la funzione che crea le sfere, le colora casualmente e le sposta sull'asse x
    GameObject  CreaSfera(int i)
    {
        GameObject mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mySphere.name = "Sfera" + i;
        return mySphere;
    }

    // Start is called before the first frame update
    void Start()
    {
        // mi richiamo la funzione con il ciclo for in modo da gestirmi il numero di sfere
        for (int i = 0; i < numerosfere; i++)
        {
  
           

            

            //Genero le variabili di confronto tra le sfere

            bool posizionesferavalida;
   

            Vector3 posizionenuovasfera;
            Color colorenuovasfera;
         
            //Confronto la distanza tra le sfere e vedo se è maggiore della minima che ho scelto
            do
            {
                // Genero le variabili casuali per colore e distanza

                float randomx = Random.Range(-100f, 100f);

                float r = Random.Range(0f, 1f);

                float b = Random.Range(0f, 1f);

                float g = Random.Range(0f, 1f);


                posizionenuovasfera = new Vector3(randomx, 0, 0);

                colorenuovasfera = new Color(r, g, b);   

                posizionesferavalida = true;

                foreach (GameObject sferainlista in SpereInGame)
                {
                    float distanzatrasfere = Vector3.Distance(posizionenuovasfera, sferainlista.transform.position);
                    if (distanzatrasfere < distanzasfere)
                    {
                        posizionesferavalida = false; 
                        break;
                    }
                  
                }

                foreach (GameObject sferainlista in SpereInGame)
                {
            
                    if (colorenuovasfera == sferainlista.GetComponent<Renderer>().material.color)
                    {
                        posizionesferavalida = false;
                        break;
                    }

                }


            }
            while ((!posizionesferavalida)) ;

            //Creo Le sfere

            GameObject miasfera = CreaSfera(i);
            miasfera.GetComponent<Renderer>().material.color = colorenuovasfera;
            miasfera.transform.position = posizionenuovasfera;
            SpereInGame.Add(miasfera);

        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
