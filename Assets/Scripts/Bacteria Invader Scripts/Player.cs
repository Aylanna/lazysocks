using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public GameObject laser;
	public float projectileSpeed = 10;
	public float projectileRepeatRate = 0.3f;

	public float speed = 15.0f;
	public float health = 200;

	private float padding = 1;
	private float xmax = -5;
	private float xmin = 5;
	private Vector3 position; 

	private bool moveRight;
	private bool moveLeft;
	private bool shoot; 
	private bool currentPlatformAndroid = false;

	private Rigidbody2D rb;

	private UIManager uiManager; 

	private void Start()
	{
		rb = GetComponent<Rigidbody2D> ();

		#if UNITY_ANDROID
		currentPlatformAndroid = true; 
		speed = 5f; 
		#endif

		position = transform.position; 
		uiManager = GameObject.Find ("UIManager").GetComponent<UIManager> ();
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		xmin = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x + padding;
		xmax = camera.ViewportToWorldPoint(new Vector3(1,1,distance)).x - padding;

		if (currentPlatformAndroid)
		{
			Debug.Log ("Android");
		} 
		else
		{
			Debug.Log ("Windows");
		}

	}

	private void Fire()
	{
		GameObject beam = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
	}

	private void Update () 
	{

		if (currentPlatformAndroid)
		{
			TouchMove (); 
		}
		else 
		{
			position.x += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			position.x = Mathf.Clamp (position.x, xmin, xmax);

			transform.position = position;

			if (Input.GetKeyDown (KeyCode.Space))
				FireControl ();

			if (Input.GetKeyUp (KeyCode.Space))
				CancelFireControl ();
		}

		position = transform.position;
		position.x = Mathf.Clamp (position.x, xmin, xmax);
		transform.position = position;			
	}
		
	private void OnTriggerEnter2D(Collider2D collider)
	{
		Projectile missile = collider.gameObject.GetComponent<Projectile>();

		if(missile)
		{
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0) {
				Die();
			}
		}
	}

	void TouchMove()
	{
		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0);

			float middle = Screen.width / 2;

			if (touch.phase == TouchPhase.Began) {
				FireControl ();
			}
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
			CancelFireControl ();
		}
	}
		
	private void MoveLeft() 
	{
		rb.velocity = new Vector2 (-speed, 0);
	}

	private void MoveRight()
	{
		rb.velocity = new Vector2 (speed, 0);
	}

	private void FireControl ()
	{
		InvokeRepeating("Fire", 0.0001f, projectileRepeatRate);
	}

	private void CancelFireControl () {
		CancelInvoke("Fire");
	}

	public void SetVelocityZero()
	{
		rb.velocity = Vector2.zero;
	}

	private void Die()
	{
		Destroy(gameObject);
		uiManager.bossDead.text = "You didn't defeat the boss";
		uiManager.GameOver ();
	}
}
