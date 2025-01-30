using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkActivity : MonoBehaviour
{
    public Text t_instructions;
    public GameObject panel_Activity;
    public GameObject boton_Activity;
    public Collider my_collider;
    public Transform botella;
    public Transform interactableVaso;

    public GameObject sombra_botella;
    public GameObject sombra_vaso;
    public GameObject sombra_vaso2;
    public GameObject liquido;

    public bool b_isBPlaced;
    public bool b_isVPlaced;
    public bool b_isServed;
    public bool b_isDrinking;
    public bool b_isPlaying = false;
    public int n;

    
    // Start is called before the first frame update
    public void StartAgain()
    {
        b_isBPlaced = false;
        b_isVPlaced = false;
        b_isServed = false;
        b_isDrinking = false;
        b_isPlaying = true;
        n = 0;

        botella.position = new Vector3(41.365f, 5.789f, -26.02f);
        interactableVaso.position = new Vector3(41.171f, 5.799f, -26.095f);
        Debug.Log("Lunch started");
        panel_Activity.SetActive(false);
        boton_Activity.SetActive(false);
        my_collider.enabled = true;
        sombra_botella.SetActive(true);
        sombra_vaso.SetActive(false);
        sombra_vaso2.SetActive(false);
        liquido.SetActive(false);
        StartCoroutine(ControlSteps());
    }

    IEnumerator ControlSteps()
    {
        ShowSteps(n); //0
        yield return new WaitUntil(() => b_isBPlaced == true);
        n++;
        ShowSteps(n); //1
        sombra_vaso.SetActive(true);
        yield return new WaitUntil(() => b_isVPlaced == true );
        my_collider.enabled = false;
        n++;
        ShowSteps(n); //2
        yield return new WaitUntil(() => b_isServed);
        n++;
        ShowSteps(n); //3
        yield return new WaitUntil(() => b_isDrinking);
        n++;
        ShowSteps(n); //4
        sombra_vaso2.SetActive(true);
        yield return new WaitUntil(() => b_isVPlaced);
        n++;
        ShowSteps(n); //5
        yield return new WaitUntil(() => b_isPlaying == false);
        EndActivity();
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter");
        if (collision.gameObject.tag == "Apple") //Vaso
        {
            b_isVPlaced = true;
        }
        if (collision.gameObject.tag == "Remolacha" ) //Botella
        {
            b_isBPlaced = true;
        }
        if (collision.gameObject.tag == "Apple" && !b_isVPlaced && b_isDrinking == true) //Vaso colocado tras beber
        {
            b_isVPlaced = true;
            b_isPlaying = false;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Trigger Enter");
        if (collision.tag == "Apple") //Vaso colocado
        {
            b_isVPlaced = true;
        }
        if (collision.tag == "Remolacha") //Botella colocada
        {
            b_isBPlaced = true;
        }

    }
    private void Update()
    {
        if (interactableVaso.position.y >=3)
        {
            b_isDrinking = true;
            b_isVPlaced = false;
        }
    }

    public void IsServing()
    {
        b_isServed = true;
        liquido.SetActive(true);
    }

    private void ShowSteps(int n)
    {
        switch (n)
        {
            case 0:
                t_instructions.text = "Coloca la botella en el área azul sobre la tabla";
                sombra_botella.SetActive(true);
                break;
            case 1:
                t_instructions.text = "Coloca el vaso en el área verde sobre la tabla";
                sombra_vaso.SetActive(true);
                break;
            case 2:
                t_instructions.text = "Vierte el líquido de la botella en el vaso";
                break;
            case 3:
                t_instructions.text = "Toma el vaso para beber";
                break;
            case 4:
                t_instructions.text = "Deja el vaso en la tabla";
                liquido.SetActive(false);
                break;
            case 5:
                EndActivity();
                break;
            default:
                t_instructions.text = "FIN";
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
