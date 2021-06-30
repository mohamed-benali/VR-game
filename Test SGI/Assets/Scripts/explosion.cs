using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class explosion : MonoBehaviour
{
    
    public GameObject prefab_pieces;

    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    float mitad_lado; // La mitad de el lado
    Vector3 centroFigura; // Centro de la figura resultant de mini cubos

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f; //Esto es para que la explosion suba hacia arriba(asi es mas dramatico)

    // Start is called before the first frame update
    void Start()
    {
        mitad_lado = cubeSize * cubesInRow / 2;
        centroFigura = new Vector3(mitad_lado, mitad_lado, mitad_lado);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Se ejecuta cuando se hace click sobre la componente
     * Explota
     */
    public void onGazeClick()
    {
        explota();
        ScoreManager scoreManager = ScoreManager.getScoreInstance(); // acceso a la variable global
        scoreManager.increase_score();

        InteractiveMusic interactiveMusic = InteractiveMusic.getMusicInstance();
        interactiveMusic.playExplosionSound();
    }
    
    public void explota()
    {
        gameObject.SetActive(false); // Para que desaparezca i se pueda apreciar la explosion

        for (int i = 0; i < cubesInRow; ++i)
        {
            for (int j = 0; j < cubesInRow; ++j)
            {
                for (int k = 0; k < cubesInRow; ++k)
                {
                    createPiece(i, j, k); // Crea los minicubos en posicions distintas como si se trocea el cubo
                }
            }
        }

        Vector3 explosionPos = this.transform.position;

        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) // Tiene rigidbody
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius, explosionUpward);
            }
        }
    }


    public void createPiece(int i, int j, int k) 
    {
        // Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity); donde myprefab es un gameobject puesto desde el inspector de unity
        // Sirve para que los trozos que explotan sean prefabs 

        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube); // Pieza tipo cubo

        if(prefab_pieces!=null)piece=Instantiate(prefab_pieces, new Vector3(0, 0, 0), Quaternion.identity);

        piece.transform.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * i, cubeSize * j, cubeSize * k) - centroFigura;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }

}
