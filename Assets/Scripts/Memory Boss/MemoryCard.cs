using UnityEngine;
using System.Collections;

public class MemoryCard : MonoBehaviour {
	public GameObject cardBack;
	public MemoryController controller;

	private int _id;

	public int id {
		get { return _id; }
	}

	public void SetCard(int id, Sprite image) {
		Debug.Log (id);
		_id = id;
		GetComponent<SpriteRenderer>().sprite = image;
	}

	public void OnMouseDown() {
		if (cardBack.activeSelf && controller.canReveal) {
			cardBack.SetActive (false);
			controller.CardRevealed (this);
		}
	}

	void OnUpdate()
	{
		foreach(Touch t in Input.touches)
		{
			if(t.phase == TouchPhase.Began)
			{
				Vector3 point = new Vector3(t.position.x, t.position.y, 0);
				Ray ray = Camera.main.ViewportPointToRay(point);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit))
				{
					hit.collider.SendMessage("OnMouseDown", null, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
		
	public void Unreveal() {
		cardBack.SetActive (true);
	}
}
