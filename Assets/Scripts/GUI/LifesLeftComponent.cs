using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesLeftComponent : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] spritesRockets;
    [SerializeField]
    private SpriteRenderer[] spritesExplosions;

    public void SetValues(int livesLeft)
    {
        /*
        for(int i = 0; i < livesLeft.Length; i++)
        {
            this.spritesRockets[i].gameObject.SetActive(true);
        }
        */
    }
}
