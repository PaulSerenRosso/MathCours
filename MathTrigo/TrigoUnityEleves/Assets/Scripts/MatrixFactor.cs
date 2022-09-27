using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Matrix4x4 = System.Numerics.Matrix4x4;
using Vector2 = UnityEngine.Vector2;

// faire la moyenne des cosinus et sinus pour obtenir la moyenne entre plusieurs angles
public class MatrixFactor : MonoBehaviour
{
    [SerializeField] private Vector2 input;
    [SerializeField] private FlexMatrix _matrix1;

    [SerializeField] private FlexMatrix _matrix2;

    [SerializeField] private FlexMatrix _matrix3;

    private void Start()
    {
        _matrix1 = new FlexMatrix(new[]
            { new FlexMatrixLine(new float[] { 1, 2, 5 }), new FlexMatrixLine(new float[] { 6, 2, 1 }) });
        _matrix2 = new FlexMatrix(new[]
            { new FlexMatrixLine(new float[] { 3, 2 }), new FlexMatrixLine(new float[] { 5, 4 }), new FlexMatrixLine(new float[] { 2, 6 }) });
        _matrix3 = FlexMatrixOperator.Multiply(_matrix1, _matrix2);
    }

   
}
    

