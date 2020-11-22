using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatIndicator : MonoBehaviour
{
    GameObject canvas;
    Material[] optionMat;
    int matSlotNum;

    public VRHandSelect handSelect;
    // Start is called before the first frame update
    void Start()
    {
        canvas = transform.GetChild(0).gameObject;
        matSlotNum = canvas.transform.childCount - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (handSelect.selected)
        {
            canvas.SetActive(true);
            SelectedMatChanger matChanger = handSelect.options.GetChild(handSelect.selectNum).GetComponent<SelectedMatChanger>();
            optionMat = matChanger.displayMat;
            for (int i = 0; i < optionMat.Length; i++)
            {
                transform.GetChild(0).GetChild(i+1).GetComponent<Image>().material = optionMat[i];
            }

            for(int i=optionMat.Length; i<matSlotNum; i++)
            {
                transform.GetChild(0).GetChild(i + 1).GetComponent<Image>().material = null;
            }
            transform.GetChild(0).GetChild(0).GetComponent<Image>().transform.localPosition = transform.GetChild(0).GetChild(matChanger.matIndex+1).GetComponent<Image>().transform.localPosition;
            //Debug.Log(transform.GetChild(0).GetChild(matChanger.matIndex+1).GetComponent<Image>().transform.localPosition);
            //Debug.Log(transform.GetChild(0).GetChild(matChanger.matIndex).GetComponent<Image>().name);
        }
        else
        {
            canvas.SetActive(false);
        }

        if(CenterControl.stage == 0)
        {
            canvas.SetActive(false);
        }
    }
}
