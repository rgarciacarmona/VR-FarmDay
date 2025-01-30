using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenActivity : MonoBehaviour
{
    public Text t_instructions;
    public GameObject panel_Activity;
    public GameObject boton_Activity;

    private int n = 120;

    // Start is called before the first frame update
    void Start()
    {
        n = 120;
    }

    public void StartAgain()
    {
        n = 120;
        StartCoroutine(ShowTime());
        panel_Activity.SetActive(false);
        boton_Activity.SetActive(false);
        Debug.Log("SE HA PULSADO START GARDEN");

    }
    // Update is called once per frame
    IEnumerator ShowTime()
    {
        while (n > 0)
        {
            yield return new WaitForSeconds(1f);
            n--;
            t_instructions.text = n + " SEGUNDOS";
        }
        EndActivity();
    }

    private void EndActivity()
    {
        t_instructions.text = "FIN";
        StopCoroutine(ShowTime());
        panel_Activity.SetActive(true);
        boton_Activity.SetActive(true);
    }
}
