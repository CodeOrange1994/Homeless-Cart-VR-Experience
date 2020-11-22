using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin_Test : MonoBehaviour
{
    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;
    [SerializeField] float zSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime);
    }
}
