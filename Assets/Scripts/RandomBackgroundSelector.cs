using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackgroundSelector : MonoBehaviour {

    public Material[] RandomMaterials;

	// Use this for initialization
	void Start () {
        if (RandomMaterials.Length > 0)
        {
            Material mat = RandomMaterials[Random.Range(0, RandomMaterials.Length)];
            this.GetComponent<MeshRenderer>().material = mat;
        }
	}
}
