using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlexMatrixOperator
{
   public static FlexMatrix Multiply(this FlexMatrix _firstMatrix, FlexMatrix _secondMatrix)
    {
        Debug.Log(_firstMatrix.RowLength + "   " +_secondMatrix.ColumnLength);
        if (_firstMatrix.RowLength == _secondMatrix.ColumnLength)
        {
            FlexMatrix result = new FlexMatrix(_firstMatrix.ColumnLength, _firstMatrix.ColumnLength);
            for (int i = 0; i < _firstMatrix.ColumnLength; i++)
            {
                FlexMatrixLine row = _firstMatrix.Rows[i];
                for (int j = 0; j < _firstMatrix.ColumnLength; j++)
                {
                    FlexMatrixLine column = _secondMatrix.Columns[j];
                    for (int k = 0; k < _firstMatrix.RowLength; k++)
                    {
                    result.Rows[i].Values[j] += row.Values[k] * column.Values[k];
                    }
                    result.UpdateColumns();
                }
            }
            return result;
        }
        throw new Exception("Matrixes are not compatibles");
    }

   public static FlexMatrix Add(this FlexMatrix _firstMatrix, FlexMatrix _secondMatrix)
   {
       if (_firstMatrix.RowLength == _secondMatrix.RowLength && _firstMatrix.ColumnLength == _secondMatrix.ColumnLength)
       {
           FlexMatrix result = new FlexMatrix(_firstMatrix.RowLength, _firstMatrix.ColumnLength); 
           for (int i = 0; i < _firstMatrix.ColumnLength; i++)
           {
               for (int j = 0; j < _firstMatrix.RowLength; j++)
               {
                   result.Rows[i].Values[j] = _firstMatrix.Rows[i].Values[j] + _secondMatrix.Rows[i].Values[j];
               }
           }

           return result;
       }
       throw new Exception("Matrixes are not compatibles");
   }
   
   
   public static FlexMatrix Subtract(this FlexMatrix _firstMatrix, FlexMatrix _secondMatrix)
   {
       if (_firstMatrix.RowLength == _secondMatrix.RowLength && _firstMatrix.ColumnLength == _secondMatrix.ColumnLength)
       {
           FlexMatrix result = new FlexMatrix(_firstMatrix.RowLength, _firstMatrix.ColumnLength); 
           for (int i = 0; i < _firstMatrix.ColumnLength; i++)
           {
               for (int j = 0; j < _firstMatrix.RowLength; j++)
               {
                   result.Rows[i].Values[j] = _firstMatrix.Rows[i].Values[j] - _secondMatrix.Rows[i].Values[j];
               }
           }
           return result;
       }
       throw new Exception("Matrixes are not compatibles");
   }
}
