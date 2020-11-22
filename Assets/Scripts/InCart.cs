using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCart : MonoBehaviour
{
    public bool state = false;
    bool prevState = false;
    public Transform cart;
    public Transform outOfCart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state && !prevState)
        {
            transform.SetParent(cart);
            transform.gameObject.layer = 9;
        }

        else if (prevState && !state)
        {
            transform.SetParent(outOfCart);
            transform.gameObject.layer = 1;
        }

        prevState = state;
    }
}
