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

	void Start(){

		colorIndex = 0;
		typeIndex = 0;
		currentType = shipType1;
		shipRenderer.sprite = currentType [typeIndex];
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
			if (typeIndex <= 0)
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