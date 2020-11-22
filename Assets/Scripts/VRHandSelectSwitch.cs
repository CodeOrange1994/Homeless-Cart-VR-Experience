using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandSelectSwitch : MonoBehaviour
{
    VRHandSelect handSelect;
    LineRenderer lineRenderer;

    public MatIndicator matIndicator;
    public bool state = false;
    // Start is called before the first frame update
    void Start()
    {
        handSelect = GetComponent<VRHandSelect>();
        lineRenderer = GetComponent<LineRenderer>();
        handSelect.enabled = state;
        lineRenderer.enabled = state;
        transform.GetChild(0).gameObject.SetActive(state);
        matIndicator.gameObject.SetActive(state);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            state = !state;
            handSelect.enabled = state;
            lineRenderer.enabled = state;
            transform.GetChild(0).gameObject.SetActive(state);
            matIndicator.gameObject.SetActive(state);
        }
    }
}
