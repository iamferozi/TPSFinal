using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Bullet")
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}
    

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Destroy(this.gameObject);
        }
    }
}
