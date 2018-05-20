using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetComponent : MonoBehaviour {

    const string MagnetActionName = "Magnet";
    const string TrashTag = "Trash";
    const string AttachTrashContainerTag = "TrashAttachmentContainer";
    const string TrashContainerTag = "TrashContainer";
    const int SpaceTrashLayer = 9;

    public bool IsMagnetActive = false;

    public PointEffector2D PointEffector;
    public GameObject TrashContainer;
    public GameObject AttachedTrashContainer;
    public Collider2D ObjectCollider;
    public GameObject MagnetEffect;

    public AudioSource SoundEffect;

    private Rigidbody2D myBody;
    
	// Use this for initialization
	void Start () {
        IsMagnetActive = false;
        myBody = GetComponent<Rigidbody2D>();
        SoundEffect.Stop();
        AttachedTrashContainer = GameObject.FindGameObjectWithTag(AttachTrashContainerTag);
        TrashContainer = GameObject.FindGameObjectWithTag(TrashContainerTag);
    }
	
	// Update is called once per frame
	void Update () {

        IsMagnetActive = Input.GetButton(MagnetActionName);
        MagnetEffect.SetActive(IsMagnetActive);
        if (IsMagnetActive)
        {
            if (!SoundEffect.isPlaying)
                SoundEffect.Play();
        }
        else
        {
            SoundEffect.Stop();
        }

        if (!IsMagnetActive && PointEffector.enabled)
        {
            List<GameObject> objectsToReparent = new List<GameObject>();
            for (int ci = 0; ci < AttachedTrashContainer.transform.childCount; ++ci)
            {
                GameObject go = AttachedTrashContainer.transform.GetChild(ci).gameObject;
                if(go.tag != TrashTag)
                {
                    continue;
                }
                if (go.transform.parent != null && go.transform.parent.gameObject.layer == go.layer)
                {
                    go = go.transform.parent.gameObject;
                }

                if (go.GetComponent<Rigidbody2D>() == null)
                {
                    Rigidbody2D body = go.AddComponent<Rigidbody2D>();
                    body.gravityScale = 0f;
                    body.mass = 20;
                    Vector2 dir = (gameObject.transform.position - go.transform.position);
                    float veloForce = myBody.velocity.magnitude;
                    body.AddForce( dir * ((myBody.angularVelocity * 0.1f) + (veloForce * -5f)), ForceMode2D.Impulse);
                }
                PlayerCollider pc = go.GetComponent<PlayerCollider>();
                if (pc != null)
                {
                    Destroy(pc);
                }
                go.layer = SpaceTrashLayer;

                objectsToReparent.Add(go);
            }

            foreach(GameObject go in objectsToReparent)
            {
                go.transform.SetParent(TrashContainer.transform);
            }
        }
        PointEffector.enabled = IsMagnetActive;
        ObjectCollider.isTrigger = IsMagnetActive;
    }
}
