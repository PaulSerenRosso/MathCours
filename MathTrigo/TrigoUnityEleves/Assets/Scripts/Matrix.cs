using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    float[,] matrix; 

    float[] vector = new float[2];


    // Start is called before the first frame update
    void Start()
    {
        float angle = 0.01f;

        /****************************************************************************************/
        /****************************************************************************************/
        // Modifiez l'initialisation de cette matrice pour en faire une matrice de rotation selon l'angle "angle"
        matrix = new float[,] { { 0, 0 }, { 0, 0 } };
        
    }

    // Update is called once per frame
    void Update()
    {
        /****************************************************************************************/
        /****************************************************************************************/
        // faites tourner l'objet autour du point 0,0 à l'aide d'une multiplication de matrices

        }

}
