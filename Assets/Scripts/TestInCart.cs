using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInCart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CenterControl.stage == 0)
        {
            if (other.tag == "Grabbable")
            {
                other.GetComponent<InCart>().state = true;
                Debug.Log(other.name + ":" + other.GetComponent<InCart>().state);
            }
            if (other.tag == "GrabbablePoint")
            {
                other.transform.parent.GetComponent<InCart>().state = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CenterControl.stage == 0)
        {
            if (other.tag == "Grabbable")
            {
                other.GetComponent<InCart>().state = false;
                Debug.Log(other.name + ":" + other.GetComponent<InCart>().state);
            }
            if (other.tag == "GrabbablePoint")
            {
                other.transform.parent.GetComponent<InCart>().state = false;
            }
        }
    }
}
