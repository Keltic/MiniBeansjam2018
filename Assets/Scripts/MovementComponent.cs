using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {

    [SerializeField]
    private GameObject thrusterBack;
    [SerializeField]
    private GameObject thrusterLeft;
    [SerializeField]
    private GameObject thrusterRight;
    [SerializeField]
    private GameObject thrusterFront;
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

        if(forward > 0)
        {
            this.thrusterBack.SetActive(true);
            rb.AddForceAtPosition(this.thrusterBack.transform.right * this.accelerationForce * forward, this.thrusterBack.transform.position, ForceMode2D.Force);
        }
        else if(forward < 0)
        {
            this.thrusterFront.SetActive(true);
            rb.AddForceAtPosition(this.thrusterFront.transform.right * -this.accelerationForce * forward, this.thrusterFront.transform.position, ForceMode2D.Force);
        }
        else
        {
            this.thrusterBack.SetActive(false);
            this.thrusterFront.SetActive(false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal > 0)
        {
            this.thrusterLeft.SetActive(true);
            rb.AddForceAtPosition(this.thrusterLeft.transform.right * this.torqueForce * horizontal, this.thrusterLeft.transform.position, ForceMode2D.Force);
        }
        else if(horizontal < 0)
        {
            this.thrusterRight.SetActive(true);
            rb.AddForceAtPosition(this.thrusterRight.transform.right * -this.torqueForce * horizontal, this.thrusterRight.transform.position, ForceMode2D.Force);
        }
        else
        {
            this.thrusterLeft.SetActive(false);
            this.thrusterRight.SetActive(false);
        }
    }
}
