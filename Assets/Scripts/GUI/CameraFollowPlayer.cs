using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    public void Update()
    {
        this.transform.position = new Vector3(this.player.position.x, this.player.position.y, this.transform.position.z);
    }
}
