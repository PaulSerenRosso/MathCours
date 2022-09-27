using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

// faire la moyenne des cosinus et sinus pour obtenir la moyenne entre plusieurs angles
public class MatrixFactor : MonoBehaviour
{
    [SerializeField] private Vector2 input;
    
    [SerializeField] private Matrix _matrix1 = new Matrix(new[]
        { new MatrixLine(new[] { 1, 2, 5 }), new MatrixLine(new[] { 6, 2, 1 }) });

    [SerializeField] private Matrix _matrix2 = new Matrix(new[]
        { new MatrixLine(new[] { 3, 2 }), new MatrixLine(new[] { 5, 4 }), new MatrixLine(new[] { 2, 6 }) });

    [SerializeField] private Matrix _matrix3;

    private void Start()
    {

    }

    [Serializable]
    class Matrix
    {
        public Matrix(MatrixLine[] _matrixLinesRow)
        {
            int currentCount = _matrixLinesRow[0].Values.Length;
            for (int i = 0; i < _matrixLinesRow.Length; i++)
            {
                if (currentCount != _matrixLinesRow[i].Values.Length)
                {
                    throw new Exception("Matrix Rows don't have the same size");
                }
            }
            
            RowCount = currentCount;
            ColumnCount = _matrixLinesRow.Length;
            Rows = new MatrixLine[ColumnCount];
            for (int i = 0; i < ColumnCount; i++)
            {
                Rows[i] = new MatrixLine(_matrixLinesRow[i].Values);
            }

            for (int i = 0; i < RowCount; i++)
            {
                Columns[i] = new MatrixLine(ColumnCount);
                for (int j = 0; j < Columns[i].Values.Length; j++)
                {
                    Columns[i].Values[j] = _matrixLinesRow[j].Values[i];
                }
            }
        }

        public Matrix(int _rowCount, int _columnCount)
        {
            RowCount = _rowCount;
            ColumnCount = _columnCount;
            Rows = new MatrixLine[ColumnCount];
            Columns = new MatrixLine[RowCount];
            for (int i = 0; i < RowCount; i++)
            {
                Columns[i] = new MatrixLine(ColumnCount);
            }
            
            for (int i = 0; i < ColumnCount; i++)
            {
                Rows[i] = new MatrixLine(RowCount);
            }
        }
        public int RowCount;
        public int ColumnCount;
        public MatrixLine[] Rows;
        public MatrixLine[] Columns;
        
        public Matrix Multiply(Matrix matrix)
        {
           
            if (RowCount == matrix.ColumnCount && ColumnCount == matrix.RowCount)
            {
                Matrix result = new Matrix(ColumnCount, ColumnCount);
                for (int i = 0; i < ColumnCount; i++)
                {
                    MatrixLine row = Rows[i];
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        MatrixLine column = matrix.Columns[j];
                        result.Rows[i].Values[j] = row.Values[j] * column.Values[i];
                    }
                }
                return result;
            }
            else
            {
                throw new Exception("Matrixes are not compatibles");
            }
        }



    }

    [Serializable]
    class MatrixLine
    {
        public MatrixLine(int[] values = null)
        {
            Values = values;
        }

        public MatrixLine(int count)
        {
            Values = new int[count];
        }

        public int[] Values;
    }
}
    

