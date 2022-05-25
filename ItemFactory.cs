using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour{
	public static Prop Potion1() {
		Prop potion1 =  new Prop(2f, 3, 1);
		potion1.itemName = "Potion#1";
		potion1.price = 25;
		return potion1;
	}
	public static Equipment Equipment1() {
		Equipment equipment1 = new Equipment(false, 2f, 1, 1);
		equipment1.itemName = "Equipment1";
		equipment1.price = 100;
		return equipment1;
	}
}
