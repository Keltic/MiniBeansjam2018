using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHowToPlayComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPrevious;
    [SerializeField]
    private GameObject buttonNext;

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClickButtonPrevious()
    {

    }

    public void OnClickButtonNext()
    {

    }

}
