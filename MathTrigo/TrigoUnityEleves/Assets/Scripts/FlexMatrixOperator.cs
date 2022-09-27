using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlexMatrixOperator
{
   public static FlexMatrix Multiply(FlexMatrix _firstMatrix, FlexMatrix _secondMatrix)
    {
        if (_firstMatrix.RowCount == _secondMatrix.ColumnCount && _firstMatrix.ColumnCount == _secondMatrix.RowCount)
        {
            FlexMatrix result = new FlexMatrix(_firstMatrix.ColumnCount, _firstMatrix.ColumnCount);
            for (int i = 0; i < _firstMatrix.ColumnCount; i++)
            {
                FlexMatrixLine row = _firstMatrix.Rows[i];
                for (int j = 0; j < _firstMatrix.ColumnCount; j++)
                {
                    FlexMatrixLine column = _secondMatrix.Columns[j];
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

   public static FlexMatrix Add()
   {
       return null;
   }
   public static FlexMatrix Subtract()
   {
       return null;
   }
   // corriger le multiply
   // value pour rotate 
}
