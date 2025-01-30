using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleTrees : MonoBehaviour
{
    public int apple_number;
    public Text t_numero;

    // Start is called before the first frame update
    void Start()
    {
        apple_number = 0;
        t_numero.text = "0";
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision - Detección colision con: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Apple"))
        {
            apple_number++;
            t_numero.text = apple_number.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger - Detección colision con: " + other.name);
        if (other.CompareTag("Apple"))
        {
            apple_number++;
            t_numero.text = apple_number.ToString();
        }
    }
}
