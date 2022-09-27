using System;
using System.Collections;
using System.Collections.Generic;
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
            RowCount = currentCount;
            ColumnCount = _matrixLinesRow.Length;
            Rows = new FlexMatrixLine[ColumnCount];
            for (int i = 0; i < ColumnCount; i++)
            {
                Rows[i] = new FlexMatrixLine(_matrixLinesRow[i].Values);
            }

            Columns = new FlexMatrixLine[RowCount];
            for (int i = 0; i < RowCount; i++)
            {
                Columns[i] = new FlexMatrixLine(ColumnCount);
                for (int j = 0; j < Columns[i].Values.Length; j++)
                {
                    Columns[i].Values[j] = _matrixLinesRow[j].Values[i];
                }
            }
        }

        public FlexMatrix(int _rowCount, int _columnCount)
        {
            RowCount = _rowCount;
            ColumnCount = _columnCount;
            Rows = new FlexMatrixLine[ColumnCount];
            Columns = new FlexMatrixLine[RowCount];
            for (int i = 0; i < RowCount; i++)
            {
                Columns[i] = new FlexMatrixLine(ColumnCount);
            }
            
            for (int i = 0; i < ColumnCount; i++)
            {
                Rows[i] = new FlexMatrixLine(RowCount);
            }
        }
        
        public int RowCount ;
        public int ColumnCount;

        public FlexMatrixLine[] Rows
        {
            get
            {
                return rows;
            }
            set
            {
                rows = value;
                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < columns[i].Values.Length; j++)
                    {
                        columns[i].Values[j] = rows[j].Values[i];
                    }
                }
                
            }
        }
        public FlexMatrixLine[] Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;
                for (int i = 0; i < ColumnCount; i++)
                {
                    for (int j = 0; j < rows[i].Values.Length; j++)
                    {
                        rows[i].Values[j] = rows[j].Values[i];
                    }
                }
            }
        }
        [SerializeField]
        private FlexMatrixLine[] rows;
        private FlexMatrixLine[] columns;
        
     



    }
