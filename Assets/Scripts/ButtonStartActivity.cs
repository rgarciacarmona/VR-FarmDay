using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonStartActivity : MonoBehaviour
{
    public UnityEvent startActivity;
    private string activity_name;

    private void Start()
    {
        startActivity.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GameManager.Instance.StartActivity(activity_name);
        }
    }

    public void GetName(string name) { activity_name = name; }
   
}
