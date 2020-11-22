using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGrabbable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<OVRGrabbable>();
        OVRGrabbable grabbable = GetComponent<OVRGrabbable>();
        Collider[] grabPoints = new Collider[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            grabPoints[i] = transform.GetChild(i).GetComponent<Collider>();
        }
        grabbable.grabPoints = grabPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
