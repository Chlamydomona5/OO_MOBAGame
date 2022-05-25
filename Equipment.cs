using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item {
	public Equipment(bool isUsable, float coolDownTime, int stackLimit, int useLimit)
		: base(isUsable, coolDownTime, stackLimit, useLimit) { }
}
