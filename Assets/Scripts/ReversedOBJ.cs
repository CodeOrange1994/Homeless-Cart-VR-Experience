using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversedOBJ : MonoBehaviour
{
    MeshCollider meshCollider;
    SelectedMatChanger matChanger;

    // Start is called before the first frame update
    void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        matChanger = GetComponent<SelectedMatChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (CenterControl.stage)
        {
            case 0:
                meshCollider.enabled = false;
                matChanger.enabled = false;
                break;
            case 1:
                meshCollider.enabled = true;
                matChanger.enabled = true;
                break;
            case 2:
                
                break;
        }
    }
}
