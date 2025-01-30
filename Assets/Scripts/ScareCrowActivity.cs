using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScareCrowActivity : MonoBehaviour
{
    public Text t_instructions;
    public GameObject panel_Activity;
    public GameObject boton_Activity;

    [Header("Game Object Transforms")]
    [Space(3)]
    //Objetos
    //public Transform go_arm_left;
    //public Transform go_arm_right;
    //public Transform go_hand_left;
    //public Transform go_hand_right;
    //public Transform go_hat;

    //[Header("Initial Transforms")]
    //[Space(3)]
    ////Posiciones iniciales
    //public Transform t_arm_left_ini;
    //public Transform t_arm_right_ini;
    //public Transform t_hand_left_ini;
    //public Transform t_hand_right_ini;
    //public Transform t_hat_ini;

    //[Header("Final Transforms")]
    //[Space(3)]
    ////Posiciones Finales
    //public Transform t_arm_left_fin;
    //public Transform t_arm_right_fin;
    //public Transform t_hand_left_fin;
    //public Transform t_hand_right_fin;
    //public Transform t_hat_fin;

    //private bool b_left_arm;
    //private bool b_right_arm;
    //private bool b_left_hand;
    //private bool b_right_hand;
    //private bool b_hat;
    private bool isPlaying = false;
    private int n;

    // Start is called before the first frame update
    public void StartAgain()
    {
        StartCoroutine(ControlSteps());
        panel_Activity.SetActive(false);
        boton_Activity.SetActive(false);

        Debug.Log("SE HA PULSADO START ESPANTAPAJAROS");

        //Reset bools
        //b_left_arm = false;
        //b_right_arm = false;
        //b_left_hand = false;
        //b_right_hand = false;
        //b_hat = false;

        //t_hand_right_ini.position = new Vector3(1.795f, 0.849f, -43.045f);
        //t_hand_right_ini.rotation = Quaternion.Euler(0, -12.28f, 0);

        //t_hand_left_ini.position = new Vector3(1.384f, 0.849f, -43.13f);
        //t_hand_left_ini.rotation = Quaternion.Euler(0, -12.28f, 0);

        //t_arm_right_ini.position = new Vector3(1.7717f, 1.1004f, -42.933f);
        //t_arm_right_ini.rotation = Quaternion.Euler(8.248f, -12.058f, -0.001f);

        //t_arm_left_ini.position = new Vector3(1.3632f, 1.0458f, -43.028f);
        //t_arm_left_ini.rotation = Quaternion.Euler(8.248f, -12.058f, -0.002f);

        //t_hat_ini.position = new Vector3(1.689f, 0.44f, -43.58f);
        //t_hat_ini.rotation = Quaternion.Euler(0, -12.28f, 0f);

        ////Reset positions
        //go_arm_left = t_arm_left_ini;
        //go_arm_right = t_arm_right_ini;
        //go_hand_left = t_hand_left_ini;
        //go_hand_right = t_hand_right_ini;
        //go_hat = t_hat_ini;

        //Control coroutine
        n = 0;
        isPlaying = true;
    }

    IEnumerator ControlSteps()
    {
        //ShowSteps(n);
        //yield return new WaitUntil(() => b_right_hand);
        //n++;
        //ShowSteps(n);
        //yield return new WaitUntil(() => b_left_hand);
        //n++;
        //ShowSteps(n);
        //yield return new WaitUntil(() => b_right_arm);
        //n++;
        //ShowSteps(n);
        //yield return new WaitUntil(() => b_left_arm);
        //n++;
        //ShowSteps(n);
        //yield return new WaitUntil(() => b_hat);
        yield return new WaitUntil(() => isPlaying == false);
        EndActivity();
    }

    private void Update()
    {
        if (isPlaying)
        {
            //if (n == 0 && !b_right_arm && go_arm_right == t_arm_right_fin)
            //    b_right_arm = true;
            //if (n == 1 && !b_left_arm && go_arm_left == t_arm_left_fin)
            //    b_left_arm = true;
            //if (n == 2 && !b_right_hand && go_hand_right == t_hand_right_fin)
            //    b_right_hand = true;
            //if (n == 3 && !b_left_hand && go_hand_left == t_hand_left_fin)
            //    b_left_hand = true;
            //if (n == 4 && !b_hat && go_hat == t_hat_fin)
            //    b_hat = true;
            //if (b_right_hand && b_left_hand && b_right_arm && b_left_arm && b_hat)
            //    isPlaying = false;
        }
    }

    private void ShowSteps(int n)
    {
        switch (n)
        {
            case 0:
                t_instructions.text = "Coloca el brazo verde en la derecha del espantapájaros ";
                break;
            case 1:
                t_instructions.text = "Coloca el brazo gris en la izquierda el espantapájaros ";
                break;
            case 2:
                t_instructions.text = "Coloca la mano verde en la derecha del espantapájaros ";
                break;
            case 3:
                t_instructions.text = "Coloca la mano amarilla en la izquierda del espantapájaros "; 
                break;
            case 4:
                t_instructions.text = "Coloca el sombrero sobre la cabeza del espantapájaros";
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
