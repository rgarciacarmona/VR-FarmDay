using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoActivity : MonoBehaviour
{
    public Text t_music;
    public GameObject panel_Activity;
    public GameObject boton_Activity;
    private int n;

    // Start is called before the first frame update
    void Start()
    {
        n = 0;
    }
    public void StartAgain()
    {
        n = 0;
        StartCoroutine(ShowMusic());
        panel_Activity.SetActive(false);
        boton_Activity.SetActive(false);
    }

    IEnumerator ShowMusic()
    {
        while (n < 20)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2.5f));
            PickNote();
            n++;
        }
        EndActivity();
    }

    /// <summary>
    /// Prints a note randomly
    /// </summary>
    private void PickNote()
    {
        int num_note = Random.Range(0, 7);
        switch (num_note)
        {
            case 0:
                t_music.text = "DO";
                break;
            case 1:
                t_music.text = "RE";
                break;
            case 2:
                t_music.text = "MI";
                break;
            case 3:
                t_music.text = "FA";
                break;
            case 4:
                t_music.text = "SOL";
                break;
            case 5:
                t_music.text = "LA";
                break;
            case 6:
                t_music.text = "SI";
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Stops the coroutine
    /// </summary>
    private void EndActivity()
    {
        t_music.text = "FIN";
        StopCoroutine(ShowMusic());
        panel_Activity.SetActive(true);
        boton_Activity.SetActive(true);
    }
}
