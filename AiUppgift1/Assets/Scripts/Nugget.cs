using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nugget : Mine
{
    private bool isOnGround;
    private bool isVisible;
    private bool canPickUp;    
    Rigidbody rb;

    public bool IsOnGround { get { return isOnGround; } set { isOnGround = value; } }
    public bool CanPickUp { get { return canPickUp; } set { canPickUp = value; } }
    public bool IsVisible { get { return isVisible; } set { isVisible = value; } }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        IsVisible = false;
        CanPickUp = false;
    }

    public void ReleaseNugget()
    {        
        if (IsOnGround == true)
        {
            rb.useGravity = true;
            Physics.gravity = new Vector3(5.0f, -9.8f , 2.0f);
            CanPickUp = false;
            IsVisible = true;
            if (transform.position.y <= 0)
            {              
                Physics.gravity = new Vector3(0.0f, -9.8f, 0.0f);              
                CanPickUp = true;
            }
        }
    }
    private void Update()
    {
        
    }

}
