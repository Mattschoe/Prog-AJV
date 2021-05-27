using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class spawnChance : MonoBehaviour // Beskriver vores scripts navn, alts� "TreeFractal"
{

    public GameObject Tree2; // Denne kode s�rger for at vi selv kan v�lge gameobject den skal referere til, inde i unity interface
    public GameObject Tree3; // Samme som ovenover, men s� vi har to at v�lge mellem
    public float SpawnPercent; // Vi laver her en float, som vi kan referere til senere, ved navn SpawnPercent

    void Start() // Denne funktion g�r s� alt kode i den, automatisk starter n�r man starter spillet.
    {
        SpawnPercent = Random.Range(0.1f, 1f); // Her v�lger vi den range den kigger p� n�r den v�lger procent, og vi har bare valgt 10%-100%. 

        if (SpawnPercent <= 0.5f) // Her v�lger vi hvad procenten skal lande p�, for at den instantiater vores gameobjects.
        {
        Instantiate(Tree2, transform.position, transform.rotation); // Denne funktion kloner et given gameobject, og placerer det p� vores empty game object. 
        Instantiate(Tree3, transform.position + new Vector3(0f, 5.039997f, 0f), transform.rotation); // Denne funktion g�r det samme som ovenover, men placerer det 5.039997 ovenover den anden. 
        }
    }
}


