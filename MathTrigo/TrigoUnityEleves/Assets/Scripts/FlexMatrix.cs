using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

 [Serializable]
   public class FlexMatrix
    {
        // get set columns et l'horizontal
        public FlexMatrix(FlexMatrixLine[] _matrixLinesRow)
        {
            int currentCount = _matrixLinesRow[0].Values.Length;
            for (int i = 0; i < _matrixLinesRow.Length; i++)
            {
                if (currentCount != _matrixLinesRow[i].Values.Length)
                {
                    throw new Exception("Matrix Rows don't have the same size");
                }
            }
            RowLength = currentCount;
            ColumnLength = _matrixLinesRow.Length;
            Rows = new FlexMatrixLine[ColumnLength];
            for (int i = 0; i < ColumnLength; i++)
            {
                Rows[i] = new FlexMatrixLine(_matrixLinesRow[i].Values);
            }

            Columns = new FlexMatrixLine[RowLength];
            for (int i = 0; i < RowLength; i++)
            {
                Columns[i] = new FlexMatrixLine(ColumnLength);
                for (int j = 0; j < Columns[i].Values.Length; j++)
                {
                    Columns[i].Values[j] = _matrixLinesRow[j].Values[i];
                }
            }
        }

        public FlexMatrix(int _RowLength, int _ColumnLength)
        {
            RowLength = _RowLength;
            ColumnLength = _ColumnLength;
            Rows = new FlexMatrixLine[ColumnLength];
            Columns = new FlexMatrixLine[RowLength];
            for (int i = 0; i < RowLength; i++)
            {
                Columns[i] = new FlexMatrixLine(ColumnLength);
            }
            for (int i = 0; i < ColumnLength; i++)
            {
                Rows[i] = new FlexMatrixLine(RowLength);
            }
        }

        public void InitializeMatrixConfiguredInEditor()
        {
            Debug.Log(Rows[0].Values.Length);
            RowLength = Rows[0].Values.Length;
            for (int i = 0; i < Rows.Length; i++)
            {
                if (RowLength != Rows[i].Values.Length)
                {
                    throw new Exception("Matrix Rows don't have the same size");
                }
            }
            Debug.Log(RowLength);
            ColumnLength = Rows.Length;
            Columns = new FlexMatrixLine[RowLength];
            for (int i = 0; i < RowLength; i++)
            {
                Columns[i] = new FlexMatrixLine(ColumnLength);
            }
            UpdateColumns();
        }
        public void UpdateColumns()
        {
            for (int i = 0; i < RowLength; i++)
            {
                for (int j = 0; j < Columns[i].Values.Length; j++)
                {
                    Columns[i].Values[j] = Rows[j].Values[i];
                }
            }
        }

        public void UpdateRows()
        {
            for (int i = 0; i < ColumnLength; i++)
            {
                for (int j = 0; j < Rows[i].Values.Length; j++)
                {
                    Rows[i].Values[j] = Rows[j].Values[i];
                }
            }  
        }
        
        public static implicit operator FlexMatrix(Vector3 vector)
        {
            FlexMatrix result = new FlexMatrix(new[] { new FlexMatrixLine(new[] { vector.x }),
                new FlexMatrixLine(new[] { vector.y }), new FlexMatrixLine(new[] { vector.z}) });
            return result;
        }
        public static implicit operator FlexMatrix(Vector2 vector)
        {
            FlexMatrix result = new FlexMatrix(new[] { new FlexMatrixLine(new[] { vector.x }),
                new FlexMatrixLine(new[] { vector.y })});
            return result;
        }
        public static implicit operator Vector3(FlexMatrix matrix)
        {
            if (matrix.RowLength == 1 && matrix.ColumnLength == 3)
            {
                Vector3 result = new Vector3(matrix.Columns[0].Values[0],
                    matrix.Columns[0].Values[1], matrix.Columns[0].Values[2]);
                return result;
            }
            throw new Exception("matrix can't be casted");
        }
        public static implicit operator Vector2(FlexMatrix matrix)
        {
            if (matrix.RowLength == 1 && matrix.ColumnLength == 2)
            {
                Vector2 result = new Vector2(matrix.Columns[0].Values[0],
                    matrix.Columns[0].Values[1]);
                return result;
            }
            throw new Exception("matrix can't be casted");
        }
        public static implicit operator FlexMatrix(float3 vector)
        {
            FlexMatrix result = new FlexMatrix(new[] { new FlexMatrixLine(new[] { vector.x }),
                new FlexMatrixLine(new[] { vector.y }), new FlexMatrixLine(new[] { vector.z}) });
            return result;
        }
        public static implicit operator FlexMatrix(float2 vector)
        {
            FlexMatrix result = new FlexMatrix(new[] { new FlexMatrixLine(new[] { vector.x }),
                new FlexMatrixLine(new[] { vector.y })});
            return result;
        }
        public static implicit operator float3(FlexMatrix matrix)
        {
            if (matrix.RowLength == 1 && matrix.ColumnLength == 3)
            {
                float3 result = new float3(matrix.Columns[0].Values[0],
                    matrix.Columns[0].Values[1], matrix.Columns[0].Values[2]);
                return result;
            }
            throw new Exception("matrix can't be casted");
        }
        public static implicit operator float2(FlexMatrix matrix)
        {
            if (matrix.RowLength == 1 && matrix.ColumnLength == 2)
            {
                float2 result = new float2(matrix.Columns[0].Values[0],
                    matrix.Columns[0].Values[1]);
                return result;
            }
            throw new Exception("matrix can't be casted");
        }
        public static implicit operator FlexMatrix(float4 vector)
        {
            FlexMatrix result = new FlexMatrix(new[] { new FlexMatrixLine(new[] { vector.x }),
                new FlexMatrixLine(new[] { vector.y }), new FlexMatrixLine(new[] { vector.z})
                , new FlexMatrixLine(new[] { vector.w})
            });
            return result;
        }
        public static implicit operator float4(FlexMatrix matrix)
        {
            if (matrix.RowLength == 1 && matrix.ColumnLength == 4)
            {
                float4 result = new float4(matrix.Columns[0].Values[0],
                    matrix.Columns[0].Values[1], matrix.Columns[0].Values[2], matrix.Columns[0].Values[3]);
                return result;
            }
            throw new Exception("matrix can't be casted");
        }

        public static implicit operator FlexMatrix(Vector4 vector)
        {
            FlexMatrix result = new FlexMatrix(new[] { new FlexMatrixLine(new[] { vector.x }),
                new FlexMatrixLine(new[] { vector.y }), new FlexMatrixLine(new[] { vector.z})
                , new FlexMatrixLine(new[] { vector.w})
            });
            return result;
        }
        public static implicit operator Vector4(FlexMatrix matrix)
        {
            if (matrix.RowLength == 1 && matrix.ColumnLength == 4)
            {
                float4 result = new Vector4(matrix.Columns[0].Values[0],
                    matrix.Columns[0].Values[1], matrix.Columns[0].Values[2], matrix.Columns[0].Values[3]);
                return result;
            }
            throw new Exception("matrix can't be casted");
        }

        [HideInInspector]
        public int RowLength;
        [HideInInspector]
        public int ColumnLength;
        
        public FlexMatrixLine[] Rows;
        public FlexMatrixLine[] Columns;
        





    }
