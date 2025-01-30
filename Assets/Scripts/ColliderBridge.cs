using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBridge : MonoBehaviour
{
    // Start is called before the first frame update
    CleanActivity _listener;
    public void Initialize(CleanActivity l)
    {
        _listener = l;
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    _listener.OnCollisionEnter(collision);
    //}
    void OnTriggerEnter(Collider other)
    {
        _listener.OnTriggerEnter(other);
    }
}
