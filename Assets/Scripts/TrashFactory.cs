using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject[] trashPrefabs;

    public GameObject GetTrashObject()
    {
        int random = UnityEngine.Random.Range(0, this.trashPrefabs.Length);

        return GameObject.Instantiate(this.trashPrefabs[random]);
    }
}
