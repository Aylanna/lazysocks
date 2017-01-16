using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
    public UIManagerT ui;

    public float carSpeed;
	public float maxPos = 2.25f;
	Vector3 position;

    private bool currentPlatformAndroid = false;

	Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();

		#if UNITY_ANDROID
				currentPlatformAndroid = true;
		#endif
	}
	
	void Start ()
	{
		position = transform.position;

		if (currentPlatformAndroid)
		{
			Debug.Log ("Android");
		} 
		else
		{
			Debug.Log ("Windows");
		}
	}

	void Update ()
	{
		if (currentPlatformAndroid)
		{
			//android specific code
			//TouchMove ();
			AccelerometerMove();
		}
		else
		{
			position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;
			position.x = Mathf.Clamp (position.x, -2.23f, 2.25f);

			transform.position = position;
		}

		position = transform.position;
		position.x = Mathf.Clamp (position.x, -2.23f, 2.25f);
		transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "EnemyCar") {

			//increase score
			GameObject enemyCar = GameObject.FindGameObjectWithTag ("EnemyCar"); 
			Destroy (enemyCar);

			ui.ScoreUpdate ();
		}
	}

	void AccelerometerMove()
	{
		float x = Input.acceleration.x;
		Debug.Log ("X = " + x);

		if (x < -0.1f)
		{
			MoveLeft ();
		} else if (x > 0.1f)
		{
			MoveRight ();	
		} 
		else {
			SetVelocityZero();
		}
	}

	void TouchMove()
	{
		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0);

			float middle = Screen.width / 2;

			if (touch.position.x < middle && touch.phase == TouchPhase.Began) {
				MoveLeft ();
			} 
			else if (touch.position.x > middle && touch.phase == TouchPhase.Began) {
				MoveRight ();
			}
		}
		else
		{
			SetVelocityZero();
		}
	}

	public void MoveLeft()
	{
		rb.velocity = new Vector2 (-carSpeed, 0);
	}
	
	public void MoveRight()
	{
		rb.velocity = new Vector2 (carSpeed, 0);
	}
	
	public void SetVelocityZero()
	{
		rb.velocity = Vector2.zero;
	}
}
