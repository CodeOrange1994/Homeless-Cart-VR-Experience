using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandSelect : MonoBehaviour
{
    public Transform hand;
    public Transform options;
    public int selectNum = 0;
    public bool selected = false;

    public Vector3 selectPos;
    public Vector2 selectUV;
    
    int layerMask;

    LineRenderer lineRenderer;
    public Material selectMat;
    public Material nonSelectMat;
    GameObject endSphere;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 9;
        //selectNum = optionNum;
        //selected = false;

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth= 0.005f;

        endSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        endSphere.transform.parent = transform;
        endSphere.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
        endSphere.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(hand.position, hand.TransformDirection(Vector3.forward), out hit, 1000, layerMask))
        {
            
            lineRenderer.SetPosition(0, hand.position);
            lineRenderer.SetPosition(1, hand.position+ hand.TransformDirection(Vector3.forward) * hit.distance);
            lineRenderer.startWidth = 0.02f;
            lineRenderer.endWidth = 0.02f;
            lineRenderer.material = selectMat;
            endSphere.transform.position = hand.position + hand.TransformDirection(Vector3.forward) * hit.distance;
            endSphere.GetComponent<MeshRenderer>().material = selectMat;

            selectNum = hit.transform.GetSiblingIndex();
            selected = true;

            selectPos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            selectUV = new Vector2(hit.textureCoord.x, hit.textureCoord.y);
            //Debug.DrawRay(hand.position, hand.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }

        else
        {
            lineRenderer.SetPosition(0, hand.position);
            lineRenderer.SetPosition(1, hand.position + hand.TransformDirection(Vector3.forward) * 10);
            lineRenderer.startWidth = 0.005f;
            lineRenderer.endWidth = 0.005f;
            lineRenderer.material = nonSelectMat;
            endSphere.transform.position = hand.position + hand.TransformDirection(Vector3.forward) * 10;
            endSphere.GetComponent<MeshRenderer>().material = nonSelectMat;

            selected = false;
            //Debug.DrawRay(hand.position, hand.TransformDirection(Vector3.forward) * 10, Color.white);
            //Debug.Log("Did not Hit");

        }

        
    }
}
