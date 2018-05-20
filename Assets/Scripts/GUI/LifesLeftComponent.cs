using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesLeftComponent : MonoBehaviour
{
    [SerializeField]
    private Image[] spritesRockets;
    [SerializeField]
    private Image[] spritesExplosions;

    public void SetValues(int livesLeft)
    {
        for(int i = 0; i < spritesRockets.Length; i++)
        {
            if (i < livesLeft)
            {
                this.spritesRockets[i].gameObject.SetActive(true);
                this.spritesExplosions[i].gameObject.SetActive(false);
            }
            else
            {
                this.spritesRockets[i].gameObject.SetActive(false);
                this.spritesExplosions[i].gameObject.SetActive(true);
            }
        }        
    }
}
