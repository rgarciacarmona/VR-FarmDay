using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class MoveToActivity : MonoBehaviour
{
    public Transform xrRig;
    // Start is called before the first frame update
    public Transform Garden_Point;
    public Transform Cantine_Point;
    public Transform Scarecrow_Point;
    public Transform Orchard_Point;
    public Transform Animal_Point;
    public Transform Piano_Point;


    public void MoveToActvity(string activity)
    {
        if (activity == "cantine")
        {
            try { 
                Teleport(Cantine_Point);
            }
            catch (IOException e)
            {
                if(e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
            }
            Debug.Log("Han pulsado Cantine");
        }
        if (activity == "garden")
        {
            Teleport(Garden_Point);
            Debug.Log("Han pulsado Garden");
        }
        if (activity == "clothes")
        {
            Teleport(Scarecrow_Point);
            Debug.Log("Han pulsado Espantapajaros");
        }
        if (activity == "piano")
        {
            Teleport(Piano_Point);
            Debug.Log("Han pulsado Piano");
        }
        if (activity == "vegetables")
        {
            Debug.Log("Han Pulsado Huerto");
            Teleport(Orchard_Point);
        }
        if (activity == "animals")
        {
            Debug.Log("Han pulsado Animales");
            Teleport(Animal_Point);
        }
    }

    void Teleport(Transform place)
    {
        xrRig = place;
    }
}
