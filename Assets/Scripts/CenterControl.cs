using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterControl : MonoBehaviour
{
    public static int stage;

    public VRHandSelect handSelect;
    public static bool changeMat = false;

    public Camera alphaCam;
    public Transform brushContainer;
    public float brushSize;

    float changeMatTimeLag = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (stage)
        {
            case 0:
                break;
            case 1:
                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    if (handSelect.selected)
                    {
                        changeMat = true;
                    }
                }
                if (!OVRInput.GetDown(OVRInput.Button.One))
                {
                    ReturnToFalse();
                }

                if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.7 && handSelect.selected)
                {
                    Vector3 uvWorldPosition = new Vector3();
                    uvWorldPosition.x = handSelect.selectUV.x - alphaCam.orthographicSize;//To center the UV on X
                    uvWorldPosition.y = handSelect.selectUV.y - alphaCam.orthographicSize;//To center the UV on Y
                    uvWorldPosition.z = 0.0f;

                    GameObject brushObj = (GameObject)Instantiate(Resources.Load("BrushTexture"),brushContainer);
                    brushObj.transform.localPosition = uvWorldPosition; //The position of the brush (in the UVMap)
                    brushObj.transform.localScale = Vector3.one * brushSize;//The size of the brush
                }
                break;
            case 2:
                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    if (handSelect.selected)
                    {
                        changeMat = true;
                    }
                }
                if(!OVRInput.GetDown(OVRInput.Button.One))
                {
                    ReturnToFalse();
                }
                break;
        }


        
    }

    void ReturnToFalse()
    {
        changeMat = false;
    }
}
