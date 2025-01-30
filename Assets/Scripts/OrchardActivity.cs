using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrchardActivity : MonoBehaviour
{
    public Text t_music;
    public GameObject panel_Activity;
    public GameObject boton_Activity;

    private string s_tag;
    private int n;

    // Start is called before the first frame update
    void Start()
    {
        n = 0;
    }
    public void StartAgain()
    {
        n = 0;
        StartCoroutine(ShowVegetable());
        panel_Activity.SetActive(false);
        boton_Activity.SetActive(false);
        Debug.Log("SE HA PULSADO START HUERTO");
    }

    IEnumerator ShowVegetable()
    {
        int c_n = Random.Range(2, 4);
        while (n < c_n)
        {     
            PickVegetable();
            yield return new WaitUntil(() =>s_tag == "next");
            n++;
        }
        EndActivity();
    }

    /// <summary>
    /// Prints a note randomly
    /// </summary>
    private void PickVegetable()
    {
        int num_veg = Random.Range(0, 4);
        switch (num_veg)
        {
            case 0:
                t_music.text = "REMOLACHA";
                s_tag = "Remolacha";
                break;
            case 1:
                t_music.text = "ZANAHORIA";
                s_tag = "Zanahoria";
                break;
            case 2:
                t_music.text = "RABANITO";
                s_tag = "Rabanito";
                break;
            case 3:
                t_music.text = "CHIRIVÍA";
                s_tag = "Chirivia";
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == s_tag)
            s_tag = "next";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == s_tag)
            s_tag = "next";
    }

    /// <summary>
    /// Stops the coroutine
    /// </summary>
    private void EndActivity()
    {
        t_music.text = "FIN";
        StopCoroutine(ShowVegetable());
        panel_Activity.SetActive(true);
        boton_Activity.SetActive(true);
    }
}
