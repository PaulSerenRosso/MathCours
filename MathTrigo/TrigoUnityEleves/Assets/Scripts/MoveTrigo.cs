using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MoveTrigo : MonoBehaviour
{
    [SerializeField] private GameObject cosObject; 
    [SerializeField] private GameObject sinObject;
  private float angle = -Mathf.PI;
    [SerializeField]
    private float speedAngle = 1;

    [SerializeField] private LineRenderer line;

    [SerializeField] private Vector2 cosStartPosition;
    [SerializeField] private Vector2 sinStartPosition;

    // Start is called before the first frame update
    void Start()
    {
       
        
        cosStartPosition = cosObject.transform.position;
       sinStartPosition =sinObject.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sinObjectPosition = sinObject.transform.position;
        Vector3 cosObjectPosition = cosObject.transform.position;
        angle += Time.deltaTime*speedAngle;
        sinObjectPosition.x = (-4*angle)/-Mathf.PI; 
        cosObjectPosition.x = (-4*angle)/-Mathf.PI;
       // angle += speedObjectY*Time.deltaTime;
        sinObjectPosition.y = Mathf.Sin(angle)*4;
        cosObjectPosition.y = Mathf.Cos(angle)*4;
        
        if (this.transform.position.x <= sinObjectPosition.x)
        {
            sinObjectPosition = sinStartPosition;
            cosObjectPosition = cosStartPosition;
            angle = -Mathf.PI;
        }
        line.SetPositions(new Vector3[]{sinObjectPosition, cosObjectPosition});
        sinObject.transform.position=  sinObjectPosition;
        cosObject.transform.position = cosObjectPosition;
            
    }
}
