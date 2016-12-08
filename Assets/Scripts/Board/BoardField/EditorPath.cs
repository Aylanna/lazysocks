using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EditorPath : MonoBehaviour {

	public Color rayColor = Color.white;
	public List<Transform> pathObjs = new List<Transform> ();
	Transform[] helperArray;

	void OnDrawGizmos() {
		Gizmos.color = rayColor;
		helperArray = GetComponentsInChildren<Transform> ();
		pathObjs.Clear ();
		foreach (Transform pathObj in helperArray) {
			if (pathObj != this.transform) {
				pathObjs.Add (pathObj);
			}
		}
		for (int i = 0; i < pathObjs.Count; i++) {
			Vector3 postion = pathObjs [i].position;
			if (i > 0) {
				Vector3 previous = pathObjs [i-1].position;
				Gizmos.DrawLine (previous, postion);
				Gizmos.DrawWireSphere (postion, 0.05f);
			}
		}
	}
}
