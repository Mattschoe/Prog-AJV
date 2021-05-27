using UnityEngine;
using System.Collections;

public class BladeFractal : MonoBehaviour // Beskriver vores scripts navn, alts� "BladeFractal"
{
    public Mesh mesh;
    public Material material;
    public int maxDepth;

    private int depth;

    private static Vector3[] childDirections = { // I denne sektion bestemmer man retningerne fraktalets b�rns b�rn, alts� kloner, g�r mod. 
        Vector3.up, // F.eks. I denne, g�r den op ad (alts� up)
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back
    };

    private static Quaternion[] childOrientations = { // Her v�lger man retningen, af de f�rste originale b�rn. Det s�rger for at vi f�r et symmetrisk tr�, s� de g�r ud til alle sider.
        Quaternion.identity,
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, 90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f)
    };



    private void Start() // Denne funktion g�r s� alt kode i den, automatisk starter n�r man starter spillet.
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh; // Denne funktion tilf�jer automatisk et component til vores object, i dette tilf�lde et mesh filter
        gameObject.AddComponent<MeshRenderer>().material = material; // Denne funktion g�r der samme som ovenover, men med en mesh renderer
        if (depth < maxDepth)
       

        {
            for (int i = 0; i < childDirections.Length; i++) // Denne kode s�rger for l�ngden de forskellige kloner bliver, i den givene retning
            {
                new GameObject("BladeFractal Child").AddComponent<BladeFractal>(). // Denne funktion skaber et nyt gameobject, og tilf�jer vores eget component vi skal bruge senere
                    Initialize(this, i);
            }
        }
    }

    public float childScale; // Vi laver her en float, som vi kan referere til senere, ved navn childScale

    private void Initialize(BladeFractal parent, int childIndex) // Vi bruger private void til at definere alle v�rdier/funktionerne nedenunder p� BladeFractal
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

