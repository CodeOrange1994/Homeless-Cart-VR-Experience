using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedMatChanger : MonoBehaviour
{
    public int stageIndex = 1;
    public Material[] optionMat;
    public Material[] displayMat;
    public int matIndex = 0;

    public VRHandSelect handSelect;

    bool change = false;
    // Start is called before the first frame update
    void Awake()
    {
        //stageIndex = transform.parent.parent.GetComponent<StageChanger>().stageIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(CenterControl.stage == stageIndex)
        {
            if (CenterControl.changeMat && (handSelect.selectNum == transform.GetSiblingIndex()))
            {
                if (matIndex < optionMat.Length - 1)
                {
                    matIndex++;
                }
                else
                {
                    matIndex = 0;
                }
                GetComponent<MeshRenderer>().material = optionMat[matIndex];
            }
        }
    }
}
