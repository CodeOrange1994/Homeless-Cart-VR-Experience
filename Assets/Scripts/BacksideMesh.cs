using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BacksideMesh : MonoBehaviour
{
    GameObject reversedModel;
    // Start is called before the first frame update
    void Start()
    {
        reversedModel = Instantiate(gameObject);
        reversedModel.transform.SetParent(transform);
        reversedModel.transform.position = transform.position;
        reversedModel.transform.rotation = transform.rotation;
        Destroy(reversedModel.GetComponent<Rigidbody>());
        Mesh mesh = reversedModel.GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
        Destroy(reversedModel.GetComponent<BacksideMesh>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
