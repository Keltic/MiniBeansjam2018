using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHowToPlayComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPrevious;
    [SerializeField]
    private GameObject buttonNext;
    [SerializeField]
    private GameObject[] pages;

    private int pagesIndex;

    public void Show()
    {
        this.pagesIndex = 0;
        this.ShowPage(0);
        this.gameObject.SetActive(true);
        this.buttonPrevious.SetActive(false);
        this.buttonNext.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClickButtonPrevious()
    {
        this.pagesIndex--;
        this.ShowPage(this.pagesIndex);
        this.buttonPrevious.SetActive(this.pagesIndex > 0);
        this.buttonNext.SetActive(true);
    }

    public void OnClickButtonNext()
    {
        this.pagesIndex++;
        this.ShowPage(this.pagesIndex);
        this.buttonPrevious.SetActive(true);
        this.buttonNext.SetActive(this.pagesIndex < this.pages.Length - 1);
    }

    private void ShowPage(int index)
    {
        for(int i = 0; i < this.pages.Length; i++)
        {
            this.pages[i].SetActive(false);
        }

        this.pages[index].SetActive(true);
    }
}
