using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Backpack : MonoBehaviour {
	public Item[] items = new Item[6];
	public GameObject[] itemSlots;
	public int Gold {
		get => _gold;
		set {
			_gold = value;
			goldText.SetText(_gold.ToString());
		}
	}
	private int _gold;
	public TMP_Text goldText;
	public readonly Color usableColor = Color.white;
	public readonly Color emptyColor = new(
		Color.gray.r, Color.gray.g, Color.gray.b,
		.5f); 
	private Backpack() { }
	public void Start() {
		for (int i = 0; i < 6; ++i) itemSlots[i].GetComponent<Image>().color 
				= emptyColor;
		goldText = GameObject.Find("Gold").GetComponent<TMP_Text>();
		Gold = 1000;
	}
	public void OnUseItem(int itemNumber) {
		if (items[itemNumber] == null) return;
		items[itemNumber].UseItem(); 
		if (items[itemNumber].isUsable)
			itemSlots[itemNumber].transform.GetChild(1).GetComponent<TMP_Text>().text
				 = items[itemNumber].stackNumber.ToString();
		if (items[itemNumber].stackNumber <= 0) {
			itemSlots[itemNumber].transform.GetChild(0).GetComponent<TMP_Text>().text
				= "Empty";
			itemSlots[itemNumber].GetComponent<Image>().color
				= emptyColor;
			items[itemNumber] = null;
			itemSlots[itemNumber].transform.GetChild(1).gameObject.SetActive(false);
		}
	}
}
