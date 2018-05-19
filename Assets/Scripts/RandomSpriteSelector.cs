using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteSelector : MonoBehaviour {

    public Sprite[] RandomSprites;

    // Use this for initialization
    void Start()
    {
        if (RandomSprites.Length > 0)
        {
            Sprite sprite = RandomSprites[Random.Range(0, RandomSprites.Length)];
            this.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
