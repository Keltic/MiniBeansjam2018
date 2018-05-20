using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSelector : MonoBehaviour {

	public Image shipRenderer;

	private ArrayList[] shiptypes;
	public Sprite[] shipType1;
	public Sprite[] shipType2;
	public Sprite[] shipType3;

	private Sprite[] currentType;
	private int colorIndex;
	private int typeIndex;

	void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerShipColorIndex"))
        {
            PlayerPrefs.SetInt("PlayerShipColorIndex", 0);
        }

        if (!PlayerPrefs.HasKey("PlayerShipTypeIndex"))
        {
            PlayerPrefs.SetInt("PlayerShipTypeIndex", 0);
        }
    }

    public void Show()
    {
        this.typeIndex = 0;
        this.colorIndex = 0;
        currentType = shipType1;
        shipRenderer.sprite = currentType[this.colorIndex];

        this.gameObject.SetActive(true);
        this.colorIndex = PlayerPrefs.GetInt("PlayerShipColorIndex");

        int savedTypeIndex = PlayerPrefs.GetInt("PlayerShipTypeIndex");

        for(int i = 0; i < savedTypeIndex; i++)
        {
            this.changeType(true);
        }
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClickButtonBack()
    {
        PlayerPrefs.SetInt("PlayerShipColorIndex", this.colorIndex);
        PlayerPrefs.SetInt("PlayerShipTypeIndex", this.typeIndex);
        GameObject.Find("Canvas_MainMenu").GetComponent<MainMenuGuiComponent>().OnClickButtonBackToMainMenu();
    }

	public void changeColor(bool dir){
		if (dir) {			
			colorIndex++;
			if (colorIndex > 3)
				colorIndex = 0;
		} else {
			colorIndex--;
			if (colorIndex == 0)
				colorIndex = 3;
		}
		shipRenderer.sprite = currentType [colorIndex];
	}

	public void changeType(bool dir){
		if (dir) {
			typeIndex++;
			if (typeIndex > 2) {
				typeIndex = 0;
			}
		} else if(dir == false){
			typeIndex--;
			if (typeIndex < 0)
				typeIndex = 2;
		}


		switch (typeIndex) {
		case 0:
			currentType = shipType1;
			break;
		case 1:
			currentType = shipType2;
			break;
		case 2:
			currentType = shipType3;
			break;
		}
		shipRenderer.sprite = currentType [colorIndex];
	
	}


}
