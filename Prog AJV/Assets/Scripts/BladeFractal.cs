using UnityEngine;
using System.Collections;

public class BladeFractal : MonoBehaviour // Beskriver vores scripts navn, altså "BladeFractal"
{
    public Mesh mesh;
    public Material material;
    public int maxDepth;

    private int depth;

    private static Vector3[] childDirections = { // I denne sektion bestemmer man retningerne fraktalets børns børn, altså kloner, går mod. 
        Vector3.up, // F.eks. I denne, går den op ad (altså up)
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back
    };

    private static Quaternion[] childOrientations = { // Her vælger man retningen, af de første originale børn. Det sørger for at vi får et symmetrisk træ, så de går ud til alle sider.
        Quaternion.identity,
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, 90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f)
    };



    private void Start() // Denne funktion gør så alt kode i den, automatisk starter når man starter spillet.
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh; // Denne funktion tilføjer automatisk et component til vores object, i dette tilfælde et mesh filter
        gameObject.AddComponent<MeshRenderer>().material = material; // Denne funktion gør der samme som ovenover, men med en mesh renderer
        if (depth < maxDepth)
       

        {
            for (int i = 0; i < childDirections.Length; i++) // Denne kode sørger for længden de forskellige kloner bliver, i den givene retning
            {
                new GameObject("BladeFractal Child").AddComponent<BladeFractal>(). // Denne funktion skaber et nyt gameobject, og tilføjer vores eget component vi skal bruge senere
                    Initialize(this, i);
            }
        }
    }

    public float childScale; // Vi laver her en float, som vi kan referere til senere, ved navn childScale

    private void Initialize(BladeFractal parent, int childIndex) // Vi bruger private void til at definere alle værdier/funktionerne nedenunder på BladeFractal
    {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition =
            childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childOrientations[childIndex];

    }
}

