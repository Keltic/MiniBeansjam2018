using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float accelerationForce = 20.0f;
    [SerializeField]
    private float torqueForce = 10.0f;

    public void FixedUpdate()
    {
        float forward = Input.GetAxis("Vertical");
        if(forward == 0)
        {
            forward = Input.GetAxis("Jump");
        }

        if(forward != 0)
        {
            rb.AddForce(this.transform.right * this.accelerationForce * forward, ForceMode2D.Force);
        }

        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal != 0)
        {
            rb.AddTorque(-horizontal * this.torqueForce, ForceMode2D.Force);
        }
    }
}
