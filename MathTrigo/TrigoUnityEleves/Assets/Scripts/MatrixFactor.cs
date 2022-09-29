using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Matrix4x4 = System.Numerics.Matrix4x4;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

// faire la moyenne des cosinus et sinus pour obtenir la moyenne entre plusieurs angles
public class MatrixFactor : MonoBehaviour
{
    [SerializeField] private Vector2 input;
    [SerializeField] private FlexMatrix _matrix1;

    [SerializeField] private Matrix4x4 _matrix4X4;
    [SerializeField] private FlexMatrix _matrix2;

    [SerializeField] private FlexMatrix _matrix3;

    private void Start()
    {
        _matrix1.InitializeMatrixConfiguredInEditor();
        _matrix2.InitializeMatrixConfiguredInEditor();
        _matrix3 = FlexMatrixOperator.Multiply( _matrix1, new Vector3(2, 5, 6));
        float3 result = _matrix3; 
        Debug.Log(result);
    }
}
    

