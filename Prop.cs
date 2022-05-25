using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 道具类
/// </summary>
public class Prop : Item {
	public Prop(float coolDownTime, int stackLimit, int useLimit) 
		: base(true, coolDownTime, stackLimit, useLimit){
	}
}
