using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalActivity : MonoBehaviour
{
    public Text t_instructions;
    public GameObject panel_Activity;
    public GameObject boton_Activity;

    public GameObject go_peinar;
    public GameObject go_posA;
    public GameObject go_posB;

    public float timer;

    private bool b_isWaterRunning;
    private bool b_isHoldingShampoo;
    private bool b_isHoldingBrush;
    private bool b_isStopBrushing;
    private bool b_isPlaying;

    private int n;

    public void StartAgain()
    {
        StartCoroutine(ControlSteps());
        panel_Activity.SetActive(false);
        boton_Activity.SetActive(false);
        Debug.Log("SE HA PULSADO START ANIMALES");

        b_isWaterRunning = false;
        b_isHoldingShampoo = false;
        b_isHoldingBrush = false;
        b_isStopBrushing = false;
        b_isPlaying = true;

        timer = 0;
        n = 0;
    }
    public void OpenWater()
    {
        b_isWaterRunning = true;
    }

    public void CloseWater()
    {
        b_isHoldingShampoo = true;
        b_isWaterRunning = false;
    }

    public void GrabShampoo()
    {
        b_isHoldingShampoo = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Remolacha")
        {
            GrabBrush();
        }
    }
    public void GrabBrush()
    {
        b_isHoldingBrush = true;
    }

    IEnumerator ControlSteps()
    {
        ShowSteps(n); //0
        yield return new WaitUntil(() => b_isWaterRunning == true);
        n++;
        ShowSteps(n); //1
        yield return new WaitUntil(() => b_isHoldingShampoo == true);
        n++;
        ShowSteps(n); //2
        yield return new WaitUntil(() => b_isWaterRunning == false);
        n++;
        ShowSteps(n); //3
        yield return new WaitUntil(() => b_isHoldingBrush == true);
        n++;
        ShowSteps(n); //4
        yield return new WaitUntil(() => b_isPlaying == false);
        EndActivity();
    }

    private void Update()
    {
        if (b_isPlaying)
        {
            if (n == 4 && !b_isStopBrushing) {
                go_peinar.SetActive(true);
                go_posA.SetActive(true);
                go_posB.SetActive(true);
            }

            if (!b_isStopBrushing && n == 4)
                timer += Time.deltaTime;

            if (!b_isStopBrushing && timer > 20f)
            {
                b_isPlaying = false;
                b_isStopBrushing = true;
            }
        }
    }

    private void ShowSteps(int n)
    {
        switch (n)
        {
            case 0:
                t_instructions.text = "Abre el grifo de agua apretando el botón azul";
                break;
            case 1:
                t_instructions.text = "Coge el bote de champú y vierte un poco sobre la oveja apretando el trigger";
                break;
            case 2:
                t_instructions.text = "Deja el bote de champú y cierra el grifo de agua aprentado el botón amarillo";
                break;
            case 3:
                t_instructions.text = "Coge el cepillo";
                break;
            case 4:
                t_instructions.text = "Peina el cuerpo de la oveja siguiendo el movimiento de la estela";
                break;
        }
    }

    private void EndActivity()
    {
        StopCoroutine(ControlSteps());
        t_instructions.text = "FIN";
        panel_Activity.SetActive(true);
        boton_Activity.SetActive(true);
    }
}
