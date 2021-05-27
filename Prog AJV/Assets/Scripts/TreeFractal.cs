using UnityEngine;
using System.Collections;

public class TreeFractal : MonoBehaviour // Beskriver vores scripts navn, altså "TreeFractal"
{

    public Mesh mesh;
    public Material material;

    public int maxDepth; // Private int er en variabel vi skaber, ved navn maxDepth
    private int depth; // Private int er en variabel vi skaber, ved navn depth



    private void Start() // Denne funktion gør så alt kode i den, automatisk starter når man starter spillet.
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh; // Denne funktion tilføjer automatisk et component til vores object, i dette tilfælde et mesh filter
        gameObject.AddComponent<MeshRenderer>().material = material; // Denne funktion gør der samme som ovenover, men med en mesh renderer
        if (depth < maxDepth)  {
            new GameObject("TreeFractal Child").AddComponent<TreeFractal>().Initialize(this); // Denne funktion skaber et nyt gameobject, og tilføjer vores eget component vi skal bruge senere
        }
    }

    public float childScale; // Vi laver her en float, som vi kan referere til senere, ved navn childScale

    private void Initialize(TreeFractal parent) // Vi bruger private void til at definere alle værdier/funktionerne nedenunder på TreeFractal 
    {
        mesh = parent.mesh;
        material = parent.material; 
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = Vector3.up * (0.5f + 0.5f * childScale);
    }
}

