using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class mamange the normal fieldaction.
 * 
 * @author Annkatrin Harms
 */
public class NormalField : BoardField {
	
	public override void DoFieldAction () {
		GameController.Instance.State = 10;
	}
}
