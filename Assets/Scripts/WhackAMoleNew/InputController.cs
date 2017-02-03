using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * This class manage the input of the user
 * 
 * @author Annkatrin Harms
 */
public class InputController : MonoBehaviour {

	private bool doInputChecking = true;
	public int score;
	public bool gameOver;
	 
	void Update () {
		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				CheckInput (Input.GetTouch (0).position);
			} 
		}
	   else {
			if (Input.GetMouseButtonDown (0)) {
				CheckInput (Input.mousePosition);
			}
		}
	}

	public void StopInputChecking() {
		doInputChecking = false;
	}

	void CheckInput(Vector3 pos) {
		if (doInputChecking) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float z_plane_of_2d_game = 0;
			Vector3 pos_at_z_0 = ray.origin + ray.direction * (z_plane_of_2d_game - ray.origin.z) / ray.direction.z;
			Vector2 point = new Vector2(pos_at_z_0.x,pos_at_z_0.y);
			RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero);
			if(hit.collider != null){
				if(hit.collider.gameObject.CompareTag("DirtyHand")){
					hit.collider.transform.gameObject.SendMessage ("WashMe", 0, SendMessageOptions.DontRequireReceiver);
					score++;
				} else {
					if(hit.collider.gameObject.CompareTag ("Tentacle")){
						hit.collider.transform.gameObject.SendMessage ("KillMe", 0, SendMessageOptions.DontRequireReceiver);
						gameOver = true;
					}
			 	}
	
			}
		}
	}				
}
