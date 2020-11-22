using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToBuilding : MonoBehaviour
{
    [SerializeField] Transform cart;
    [SerializeField] Transform environment_1;
    [SerializeField] Transform environment_2;
    [SerializeField] Transform alphaCameras;

    [SerializeField] float transformTime = 18f;
    [SerializeField] float targetScale = 20f;
    float scaleSpeed;
    [SerializeField] float moveAwaySpeed = 10f;

    float currentTime = 0;

    Vector3 startPosition;
    Vector3 targetPosition;
    Vector3 startEulerAngles;
    bool startTransformation = false;
    int objNum; // obj number in cart

    // Start is called before the first frame update
    void Start()
    {
        scaleSpeed = targetScale / transformTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (CenterControl.stage == 0 && (OVRInput.GetDown(OVRInput.Button.Three) || Input.GetKeyDown(KeyCode.T)))
        {
            targetPosition = cart.position;
            targetPosition.y = -1;
            startPosition = cart.position;
            startEulerAngles = cart.eulerAngles;

            objNum = cart.GetChild(3).childCount;
            TurnOffRigidbody();
            //Debug.Log("111");
            SwitchCollider();
            SetUpReversedBag_2();

            startTransformation = true;
            CenterControl.stage = 1;

            VR_Move.mode = MoveMode.FLY;
        }

        Transformation();
    }

    void TurnOffRigidbody()
    {
        for(int i = 0; i < objNum; i++)
        {
            Rigidbody rigidbody = cart.GetChild(3).GetChild(i).GetComponent<Rigidbody>();
            Destroy(rigidbody);
        }
    }

    void SwitchCollider()
    {
        for (int i = 0; i < objNum; i++)
        {
            Transform objTransform = cart.GetChild(3).GetChild(i);
            ConcaveCollider concaveCollider = objTransform.GetComponent<ConcaveCollider>();
            if (concaveCollider == null)
            {
                objTransform.GetComponent<MeshCollider>().convex = false;
            }
            else
            {
                for(int j = 0; j < objTransform.childCount; j++)
                {
                    Destroy(objTransform.GetChild(j).gameObject);
                }
                Destroy(objTransform.GetComponent<ConcaveCollider>());
                objTransform.GetComponent<MeshCollider>().enabled = true;
            }
        }
    }


    //In progress
    void SetUpAlphaCameras()
    {
        for (int i = 0; i < objNum; i++)
        {
            GameObject alphaCamSet = (GameObject)Instantiate(Resources.Load("Alpha Cam Set Entity"),alphaCameras);
            alphaCamSet.transform.position = new Vector3(100 + i * 2, 0, 0);
        }
    }

    //Deprecated
    void SetUpBackSideMesh()
    {
        for (int i = 0; i < objNum; i++)
        {
            Transform objTransform = cart.GetChild(3).GetChild(i);
            objTransform.gameObject.AddComponent<BacksideMesh>();
        }
    }

    //Deprecated
    void SetUpReversedBag_2()
    {
        Transform objTransform = cart.GetChild(3).GetChild(0);
        GameObject reversedBag2 = (GameObject)Instantiate(Resources.Load("Reversed Bag_2"), objTransform);
        reversedBag2.transform.position = objTransform.position;
        reversedBag2.transform.rotation = objTransform.rotation;
        reversedBag2.GetComponent<SelectedMatChanger>().handSelect = GameObject.Find("VR Hand Select").GetComponent<VRHandSelect>();
    }

    void Transformation()
    {
        if (currentTime < transformTime && startTransformation)
        {
            currentTime += Time.deltaTime;
            //Debug.Log(currentTime);
            cart.position = Vector3.Lerp(startPosition, targetPosition, currentTime / transformTime);
            cart.eulerAngles = Vector3.Lerp(startEulerAngles + Vector3.zero, startEulerAngles + Vector3.right * 180, currentTime / transformTime);
            cart.localScale = Vector3.Lerp(Vector3.one, Vector3.one * targetScale, currentTime / transformTime);
            environment_1.Translate(Vector3.forward * moveAwaySpeed * Time.deltaTime, Space.World);
            environment_2.Translate(Vector3.back * moveAwaySpeed * Time.deltaTime, Space.World);
        }
        if (currentTime >= transformTime)
        {
            environment_1.gameObject.SetActive(false);
            environment_2.gameObject.SetActive(false);
        }
    }

    /*
    float Acceleration(float speed, float currentTime)
    {
        if(currentTime == 0)
        {

        }
        return 0;
    }*/
}
