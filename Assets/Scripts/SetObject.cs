using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObject : MonoBehaviour
{
    [SerializeField] bool convex = true;
    [SerializeField] Transform cart;
    [SerializeField] Transform outOfCart;
    // Start is called before the first frame update
    void Start()
    {
        string name = gameObject.name;
        Transform objectTransform = transform.GetChild(0);
        objectTransform.gameObject.name = name;
        objectTransform.SetParent(transform.parent);

        objectTransform.gameObject.AddComponent<InCart>();
        objectTransform.gameObject.GetComponent<InCart>().cart = cart;
        objectTransform.gameObject.GetComponent<InCart>().outOfCart = outOfCart;

        if (convex)
        {
            objectTransform.GetComponent<MeshCollider>().convex = true;
            objectTransform.tag = "Grabbable";
            objectTransform.gameObject.AddComponent<OVRGrabbable>();
        }
        else
        {
            objectTransform.gameObject.AddComponent<SetGrabbable>();
            for (int i = 0; i < objectTransform.childCount; i++)
            {
                objectTransform.GetChild(i).tag = "GrabbablePoint";
            }
            objectTransform.GetComponent<MeshCollider>().enabled = false;
        }
        //Debug.Log("11");
        objectTransform.gameObject.AddComponent<Rigidbody>();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
