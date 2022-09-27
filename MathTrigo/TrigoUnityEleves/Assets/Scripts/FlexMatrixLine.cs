using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class FlexMatrixLine
{
    public FlexMatrixLine(float[] values = null)
    {
        Values = values;
    }
    public FlexMatrixLine(int count)
    {
        Values = new float[count];
    }
    public float[] Values;
}