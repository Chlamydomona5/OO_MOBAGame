using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 物品类
/// </summary>
public abstract class Item {
	public int stackNumber;
	public int price;
	public string itemName;
	public bool isUsable;
	public int stackLimit;
	private float coolDownTime;
	private int useLimit;
	public Item(bool isUsable) {
		this.isUsable = isUsable;
		if (isUsable == false) {
			stackLimit = 1;
			useLimit = 1;
			coolDownTime = 1f;
		}
		else {
			stackLimit = 5;
			useLimit = 1;
			coolDownTime = 1f;
		}
	}
	public Item(bool isUsable, float coolDownTime, int stackLimit, int useLimit) {
		this.isUsable = isUsable;
		this.coolDownTime = coolDownTime;
		this.stackLimit = stackLimit;
		this.useLimit = useLimit;
	}
	public void UseItem() {
		if (!isUsable) return;
		--stackNumber;
	}
}
