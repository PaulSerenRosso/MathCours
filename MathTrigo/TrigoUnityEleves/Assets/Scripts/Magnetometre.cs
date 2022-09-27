using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetometre : MonoBehaviour
{
    public float AngleMagnetometre=0f;
    public float BruitMagnetometre = 0.3f;

    public List<float> ValeursMagnetometre=new List<float>();
    private int CptMagnetometre;
    private int SizeOfListMagnetometre=8;

    GameObject Magneto;
    GameObject Boussole;

    // Start is called before the first frame update
    void Start()
    {
        Magneto = GameObject.Find("Magnetometre");
        Boussole = GameObject.Find("Boussole");
        for (int i=0;i<SizeOfListMagnetometre;i++)
        {
            ValeursMagnetometre.Add(getCompassValue());
        }

    }

    // Update is called once per frame
    void Update()
    {
        float valeurMagneto = getCompassValue();
        // tourne le sprite Magneto pour montrer la valeur brute du magn�tometre
        Magneto.transform.eulerAngles=new Vector3(0, 0, valeurMagneto*180/Mathf.PI);
        /***********************************************************************************/
        /***********************************************************************************/
        /***********************************************************************************/
        /***********************************************************************************/
        // �crivez ici le code qui affichera une belle boussole qui bouge tout en douceur






        /***********************************************************************************/
        /***********************************************************************************/
        /***********************************************************************************/
        /***********************************************************************************/
        Boussole.transform.eulerAngles = new Vector3(0, 0, valeurMagneto * 180 / Mathf.PI);
    }





    
    // renvois la position instantan�e du magn�tom�tre
    public float getCompassValue()
    {
        // r�cup�re une valeur brute
        float RawMagnetoMetreValue = Random.Range(-BruitMagnetometre, BruitMagnetometre);

        // place cette valeur dans la liste
        ValeursMagnetometre.Add(RawMagnetoMetreValue);

        // r�duit la liste � n �l�ments
        if (ValeursMagnetometre.Count > SizeOfListMagnetometre)
            ValeursMagnetometre.RemoveAt(0);

        return (AngleMagnetometre + RawMagnetoMetreValue);
    }

}
