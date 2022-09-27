using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
//https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/operators/operator-overloading
//https://stackoverflow.com/questions/1407689/how-do-i-provide-custom-cast-support-for-my-class
//https://www.youtube.com/watch?v=zjMuIxRvygQ
//le blocage de cardan
/*
 *     public static Vector3 operator *(Quaternion rotation, Vector3 point)
    {
      float num1 = rotation.x * 2f;
      float num2 = rotation.y * 2f;
      float num3 = rotation.z * 2f;
      float num4 = rotation.x * num1;
      float num5 = rotation.y * num2;
      float num6 = rotation.z * num3;
      float num7 = rotation.x * num2;
      float num8 = rotation.x * num3;
      float num9 = rotation.y * num3;
      float num10 = rotation.w * num1;
      float num11 = rotation.w * num2;
      float num12 = rotation.w * num3;
      Vector3 vector3;
      vector3.x = (float) ((1.0 - ((double) num5 + (double) num6)) * (double) point.x + ((double) num7 - (double) num12) * (double) point.y + ((double) num8 + (double) num11) * (double) point.z);
      vector3.y = (float) (((double) num7 + (double) num12) * (double) point.x + (1.0 - ((double) num4 + (double) num6)) * (double) point.y + ((double) num9 - (double) num10) * (double) point.z);
      vector3.z = (float) (((double) num8 - (double) num11) * (double) point.x + ((double) num9 + (double) num10) * (double) point.y + (1.0 - ((double) num4 + (double) num5)) * (double) point.z);
      return vector3;
    }
 */
public class ComplexNumber : MonoBehaviour
{
    [SerializeField]
    private Complex test1 = new Complex(2, 3);

    [SerializeField] private Complex test2;
    private GameObject tank;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 directionNormalized = transform.position.normalized;
     //   test1 = Complex.FromPolarCoordinates(Vector3.Distance(Vector3.zero, transform.position); 
        Complex tankComplex = new Complex(tank.transform.position.x, tank.transform.position.y);
        test2 = new Complex(transform.position.x, transform.position.y);
        Complex direction = Complex.Subtract(tankComplex,test2);
        double distance = direction.Magnitude;
        double angle = direction.Phase;
        Quaternion finalAngle =  Quaternion.Euler(0, 0, (float) angle);
            
            
            Mathf.Atan2(directionNormalized.y, directionNormalized.x);
        
        Complex.Multiply(test1, test2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
