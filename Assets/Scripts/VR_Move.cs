using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveMode {FLY,GROUND};
public class VR_Move : MonoBehaviour
{
    public float speed = 0.1f;
    public Transform vrCamera;

    public static MoveMode mode = MoveMode.GROUND;

    Vector2 stick;

    float forwardMove;
    float sideMove;
    Vector3 forward;
    Vector3 right;
    Vector3 desiredMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        forwardMove = stick.y;
        sideMove = stick.x;

        if (mode == MoveMode.GROUND)
        {
            //camera forward and right vectors:
            forward = vrCamera.transform.forward;
            right = vrCamera.transform.right;

            //project forward and right vectors on the horizontal plane (y = 0)

            forward = transform.InverseTransformDirection(forward);
            forward.y = 0;
            right = transform.InverseTransformDirection(right);
            right.y = 0;
            forward = transform.TransformDirection(forward);
            right = transform.TransformDirection(right);
            forward.Normalize();
            right.Normalize();
        }
        if(mode == MoveMode.FLY)
        {
            //camera forward and right vectors:
            forward = vrCamera.transform.forward;
            right = vrCamera.transform.right;
        }

        //this is the direction in the world space we want to move:
        desiredMoveDirection = forward * forwardMove + right * sideMove;

        //now we can apply the movement:
        transform.Translate(desiredMoveDirection * speed * Time.deltaTime, Space.Self);
    }
}
