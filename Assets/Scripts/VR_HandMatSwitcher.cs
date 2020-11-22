using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_HandMatSwitcher : MonoBehaviour
{
    public Material mat;
    bool switched = false;
    GameObject leftHand;
    GameObject rightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!switched)
        {
            leftHand = GameObject.Find("hand_left_renderPart_0");
            rightHand = GameObject.Find("hand_right_renderPart_0");
            if (leftHand != null && rightHand != null)
            {
                leftHand.GetComponent<SkinnedMeshRenderer>().material = mat;
                rightHand.GetComponent<SkinnedMeshRenderer>().material = mat;
                switched = true;
            }
        }
    }
}
