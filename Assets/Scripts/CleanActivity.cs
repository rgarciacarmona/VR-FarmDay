using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanActivity : MonoBehaviour
{
    public Text t_instructions;
    public GameObject panel_Activity;
    public GameObject boton_Activity;
    public GameObject soap1;
    public GameObject soap2;
    public GameObject balda;
    public GameObject botonjabon;

    public Canvas canvas_manos;
    public Image left_hand;
    public Image right_hand;
    public Collider left_hand_collider;
    public Collider right_hand_collider;
    public Collider soap_collider;
    public ParticleSystem go_particleSystem;

    public bool b_isWaterRunning;
    public bool b_isHandWeat_r;
    public bool b_isHandWeat_l;
    public bool isChangingColor_r;
    public bool isChangingColor_l;
    public bool b_isHoldingSoap;
    public bool b_isPlaying;
    public bool b_isJabonPlaced;

    private int n;
    private float l_a;
    private float r_a;

    public void StartAgain()
    {
        b_isJabonPlaced = false;
        b_isWaterRunning = false;
        b_isHandWeat_r = false;
        b_isHandWeat_l = false;
        isChangingColor_r = false;
        isChangingColor_l = false;

        b_isHoldingSoap = false;
        b_isPlaying = true;
        botonjabon.SetActive(false);
        canvas_manos.enabled = false;
        l_a = 0;
        r_a = 0;
        n = 0;
        StartCoroutine(ControlSteps());
        panel_Activity.SetActive(false);
        boton_Activity.SetActive(false);
    }

    public void OpenWater()
    {
        b_isWaterRunning = true;
    }

    public void CloseWater()
    {
        if(n>3)
            b_isWaterRunning = false;
    }

    IEnumerator ControlSteps()
    {
        ShowSteps(n); //0 Encender el grifo
        yield return new WaitUntil(() => b_isWaterRunning == true);
        soap1.SetActive(false);
        soap2.SetActive(false);
        balda.SetActive(false);
        n++;
        ShowSteps(n); //1 Poner los guantes bajo el agua
        yield return new WaitUntil(() => b_isHandWeat_r == true && b_isHandWeat_l == true);
        StopCoroutine(FillLeft());
        StopCoroutine(FillRight());
        canvas_manos.enabled = false; //se desactiva el canvas
        soap1.SetActive(true); //aparece el jabon
        soap2.SetActive(true);
        balda.SetActive(true);
        n++;
        ShowSteps(n); //2 cojo el jabon y hago pompas
        yield return new WaitUntil(() => b_isHoldingSoap == true);
        b_isHandWeat_r = false;
        b_isHandWeat_l = false;
        isChangingColor_l = false;
        isChangingColor_r = false;
        n++;
        ShowSteps(n); //3 dejo el jabón
        yield return new WaitUntil(() =>b_isJabonPlaced == true);
        canvas_manos.enabled = true; //habilito el canvas
        l_a = 0;
        r_a = 0;
        n++;
        ShowSteps(n); //4 cojo los guantes
        yield return new WaitUntil(() => b_isHandWeat_r == true && b_isHandWeat_l == true);
        StopCoroutine(FillLeft());
        StopCoroutine(FillRight());
        canvas_manos.enabled = false;
        n++;
        ShowSteps(n); //5 cierro el grifo
        yield return new WaitUntil(() => b_isWaterRunning == false);
        t_instructions.text = "FIN";
        EndActivity();
    }

    private void Update()
    {
        if (b_isPlaying)
        {
            if(n== 1)
            {
                if (left_hand_collider.gameObject != gameObject)
                {
                    ColliderBridge cb = left_hand_collider.gameObject.AddComponent<ColliderBridge>();
                    cb.Initialize(this);
                }
                if (right_hand_collider.gameObject != gameObject)
                {
                    ColliderBridge cb = right_hand_collider.gameObject.AddComponent<ColliderBridge>();
                    cb.Initialize(this);
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "leftC" && !isChangingColor_l)
        {
            StartCoroutine(FillLeft());
            isChangingColor_l = true;
        }
        if (other.tag == "rightC" && !isChangingColor_r)
        {
            StartCoroutine(FillRight());
            isChangingColor_r = true;
        }

        if (other.tag == "Chirivia")
        {
            Debug.Log("Trigger Interaccionando jabones");
            b_isHoldingSoap = true;
            go_particleSystem.Play();
            botonjabon.SetActive(true);
        }
    }

    public void JabonPlaced()
    {
        b_isJabonPlaced = true;
    }

    IEnumerator FillLeft()
    {
        while (!b_isHandWeat_l && l_a<2)
        {
            l_a += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        b_isHandWeat_l = true;
    }

    IEnumerator FillRight()
    {
        while (!b_isHandWeat_r && r_a < 2)
        {
            r_a += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        b_isHandWeat_r = true;
    }

    private void ShowSteps(int n)
    {
        switch (n)
        {
            case 0:
                t_instructions.text = "Abre el grifo de agua apretando el botón azul";
                break;
            case 1:
                t_instructions.text = "Coge los guantes y coloca las palmas hacia arriba bajo el grifo";
                canvas_manos.enabled = true;
                break;
            case 2:
                t_instructions.text = "Coge el jabón y enjabonate las manos";
                break;
            case 3:
                canvas_manos.enabled = true;
                t_instructions.text = "Deja el jabón en la zona verde y coge los guantes";
                break;
            case 4:
                canvas_manos.enabled = true;
                t_instructions.text = "Coloca las palmas hacia arriba bajo el grifo";
                break;
            case 5:
                t_instructions.text = "Cierra el grifo de agua apretando el boton amarillo";
                break;
            default:
                break;
        }
    }

    private void EndActivity()
    {
        StopCoroutine(ControlSteps());
        panel_Activity.SetActive(true);
        boton_Activity.SetActive(true);
    }
}
