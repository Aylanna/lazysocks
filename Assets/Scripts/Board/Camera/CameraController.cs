using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera cam;
	public GameObject target;
	private int zoom  = 50;
	private float smooth = 5;
	// Use this for initialization
	void Start () {
		//cam.fieldOfView = Mathf.Lerp (cam.fieldOfView, zoom, Time.deltaTime * smooth);
	}
	
	// Update is called once per frame
	void Update () {
		
		//cam.fieldOfView = Mathf.Lerp (cam.fieldOfView, zoom, Time.deltaTime * smooth);
	}
}
