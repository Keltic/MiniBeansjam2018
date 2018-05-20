using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {

    const string AttachTrashContainerTag = "TrashAttachmentContainer";

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
    [SerializeField]
    private float trashMassFactor = 0.001f;

    private Rigidbody2D myBody;
    private MagnetComponent magnet;
    public GameObject AttachTrashContainer;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        magnet = GetComponent<MagnetComponent>();
        AttachTrashContainer = GameObject.FindGameObjectWithTag(AttachTrashContainerTag);
    }

    public void FixedUpdate()
    {
        Transform containerTransform = AttachTrashContainer.transform;
        int numChilds = containerTransform.childCount;
        float overallMass = 0f;
        for (int ci = 0; ci < containerTransform.childCount; ++ci)
        {
            Rigidbody2D body = containerTransform.GetChild(ci).gameObject.GetComponent<Rigidbody2D>();
            if (body)
            {
                overallMass += body.mass;
            }
        }

        float massFactor = overallMass * trashMassFactor;

        myBody.drag = magnet.IsMagnetActive ? 0.5f +  (numChilds * massFactor) : 0.5f;
        myBody.angularDrag = magnet.IsMagnetActive ?  0.5f + (numChilds * massFactor * 150.0f) : 0.5f;

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


        myBody.angularVelocity = Mathf.Clamp(myBody.angularVelocity, -50f, 50f);
    }
}
