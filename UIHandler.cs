using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour {
	public GameObject shopPanel;
	public Backpack backpack;
	public void OnShopButtonClick() {
		if (shopPanel.activeSelf) shopPanel.SetActive(false);
		else shopPanel.SetActive(true);
	}
	public void OnShopItem1ButtonClick() {
		CreateItem(ItemFactory.Potion1());
	}
	public void OnShopItem2ButtonClick() {
		CreateItem(ItemFactory.Equipment1());
	}
	private void CreateItem(Item item) {
		int slotNumber = 0;
		for (; slotNumber < 6
			&& backpack.items[slotNumber] != null
			&& (backpack.items[slotNumber].itemName != item.itemName
			|| backpack.items[slotNumber].stackNumber >= backpack.items[slotNumber].stackLimit);
			++slotNumber) ;
		if (slotNumber == 6) return;
		backpack.Gold -= item.price;
		if (backpack.items[slotNumber] == null) {
			backpack.items[slotNumber] = item;
			backpack.items[slotNumber].stackNumber++;
			if (item.isUsable) {
				backpack.itemSlots[slotNumber].GetComponent<Image>().color
					= backpack.usableColor;
				backpack.itemSlots[slotNumber].transform.GetChild(1).gameObject.SetActive(true);
				backpack.itemSlots[slotNumber].transform.GetChild(1).GetComponent<TMP_Text>().text
					= backpack.items[slotNumber].stackNumber.ToString();
			}
			else backpack.itemSlots[slotNumber].GetComponent<Image>().color
				 = backpack.usableColor;
			backpack.itemSlots[slotNumber].transform.GetChild(0).GetComponent<TMP_Text>().text
				= item.itemName;
			return;
		}
		if (backpack.items[slotNumber].itemName == item.itemName) {
			backpack.items[slotNumber].stackNumber++;
			if (item.isUsable) backpack.itemSlots[slotNumber].transform.GetChild(1).gameObject.SetActive(true);
			backpack.itemSlots[slotNumber].transform.GetChild(1).GetComponent<TMP_Text>().text
				= backpack.items[slotNumber].stackNumber.ToString();
		}
	}
}
