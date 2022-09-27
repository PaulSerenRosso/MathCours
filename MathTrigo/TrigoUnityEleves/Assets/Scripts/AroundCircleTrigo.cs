using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AroundCircleTrigo : MonoBehaviour
{
    [SerializeField]
    private GameObject trigoObject;

    private float angle = Mathf.PI;
    [SerializeField] private float speedAngle = 1;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private bool isInverse;

    [SerializeField] private Transform startPoint;
    [SerializeField] private float size;
    private void Start()
    {

    }

    private void Update()
    { int direction = 1;
        if (isInverse)
        {
            direction = -1;
        }
        angle += Time.deltaTime * speedAngle*direction;
        Vector3 trigoObjectPosition = trigoObject.transform.position;
        trigoObjectPosition = startPoint.TransformPoint(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle))*size);
        trigoObject.transform.position = trigoObjectPosition;
        _lineRenderer.SetPositions(new Vector3[]{startPoint.position, trigoObjectPosition});
    }
}
