using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToPlayerPositionAndRotation : MonoBehaviour {

    public GameObject Player;
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.SetPositionAndRotation( Player.transform.position, Player.transform.rotation);
	}
}
