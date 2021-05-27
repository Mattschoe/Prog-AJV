using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class spawnChance : MonoBehaviour // Beskriver vores scripts navn, altså "TreeFractal"
{

    public GameObject Tree2; // Denne kode sørger for at vi selv kan vælge gameobject den skal referere til, inde i unity interface
    public GameObject Tree3; // Samme som ovenover, men så vi har to at vælge mellem
    public float SpawnPercent; // Vi laver her en float, som vi kan referere til senere, ved navn SpawnPercent

    void Start() // Denne funktion gør så alt kode i den, automatisk starter når man starter spillet.
    {
        SpawnPercent = Random.Range(0.1f, 1f); // Her vælger vi den range den kigger på når den vælger procent, og vi har bare valgt 10%-100%. 

        if (SpawnPercent <= 0.5f) // Her vælger vi hvad procenten skal lande på, for at den instantiater vores gameobjects.
        {
        Instantiate(Tree2, transform.position, transform.rotation); // Denne funktion kloner et given gameobject, og placerer det på vores empty game object. 
        Instantiate(Tree3, transform.position + new Vector3(0f, 5.039997f, 0f), transform.rotation); // Denne funktion gør det samme som ovenover, men placerer det 5.039997 ovenover den anden. 
        }
    }
}


