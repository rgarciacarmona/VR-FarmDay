using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGameManager : MonoBehaviour
{
    private bool calib = false;
    private bool i1_passed = false;
    private bool i2_passed = false;
    private bool i3_passed = false;
    private bool i4_passed = false;

    public int itemOnGoing;
    public Text count_down_text;

    // Start is called before the first frame update
    void Start()
    {
        itemOnGoing = 0;
        StartCoroutine(StartCalibration());
        StartCoroutine(StartItemEvaluation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartCalibration()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(StartCountDown());
        Matrix4x4 first_calib_mat4 = Calibrate();
        yield return new WaitForSeconds(5f);
        StartCoroutine(StartCountDown());
        Matrix4x4 second_calib_mat4 = Calibrate();
        CompareCalibMatrix(first_calib_mat4, second_calib_mat4);
        yield return new WaitUntil(() => calib == true);
    }

    Matrix4x4 Calibrate()
    {
        Matrix4x4 ret = new Matrix4x4();
        return ret;
    }

    void CompareCalibMatrix(Matrix4x4 one, Matrix4x4 two)
    {

    }

    IEnumerator StartItemEvaluation()
    {
        ChangePanelInfo(1);
        yield return new WaitUntil(()=> i1_passed== true);
        ChangePanelInfo(2);
        yield return new WaitUntil(() => i2_passed == true);
        ChangePanelInfo(3);
        yield return new WaitUntil(() => i3_passed == true);
        ChangePanelInfo(4);
        yield return new WaitUntil(() => i4_passed == true);
    }

    void ChangePanelInfo(int current_item)
    {
        itemOnGoing++;
    }

    IEnumerator StartCountDown()
    {
        yield return new WaitForSeconds(1f);
        count_down_text.text = "3";
        yield return new WaitForSeconds(1f);
        count_down_text.text = "2";
        yield return new WaitForSeconds(1f);
        count_down_text.text = "1";
        yield return new WaitForSeconds(1f);
        EvaluatePose();
    }


    void EvaluatePose()
    {
        switch (itemOnGoing)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                return;
        }
    }
}
