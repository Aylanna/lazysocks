using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private BarrelSpawner barrelSpawner;
	private GameObject goalItem; 
	private Rigidbody2D rb;

	[SerializeField] private float maxSpeed;
	[SerializeField] private float jumpForce;

	private float speed; 
	private bool facingRight, jumping, isDead, hasWon, isGrounded; 

	public bool onLadder;
	public float climbSpeed;
	private float gravityStore;

	private SpriteRenderer gameOverSprite;
	private SpriteRenderer winSprite; 

	private bool currentPlatformAndroid = false;

	void Awake() {

		rb = GetComponent<Rigidbody2D> ();

		goalItem = GameObject.Find ("GoalItem");

		if (GameObject.Find("DonkeyKong") != null) barrelSpawner = GameObject.Find("DonkeyKong").GetComponent<BarrelSpawner>();
		if (GameObject.Find ("Win") != null) winSprite = GameObject.Find ("Win").GetComponent<SpriteRenderer>();
		if (GameObject.Find ("GameOver") != null) gameOverSprite = GameObject.Find ("GameOver").GetComponent<SpriteRenderer>();

		facingRight = true;
		isDead = false; 
		hasWon = false; 

		gravityStore = rb.gravityScale; 
	}

	void Start() {

		#if UNITY_ANDROID
		currentPlatformAndroid = true; 
		#endif

		if (currentPlatformAndroid)
		{
			Debug.Log ("Android");
		} 
		else
		{
			Debug.Log ("Windows");
		}
	}
		
	void Update() {

		if (currentPlatformAndroid) {
			MovePlayer (speed);
			Flip ();
		} else {
			MovePlayer (speed);
			Flip ();
		}

		HandleInput ();

		if (onLadder) {
			rb.gravityScale = 0f; 
			 
			rb.velocity = new Vector2 (rb.velocity.x, climbSpeed);
		}
		if (!onLadder) {
			rb.gravityScale = gravityStore; 
		}
	}

	void HandleInput () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {
			moveLeft (); 
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.A)) {
			stopMoving (); 
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {
			moveRight (); 
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.D)) {
			stopMoving (); 
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.Space)) {
			Jump ();
		}
	}

	void Flip () {
		if (speed > 0 && !facingRight || speed < 0 && facingRight) {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	void MovePlayer(float playerSpeed) { 
		rb.velocity = new Vector3 (speed, rb.velocity.y, 0);
	}

	void OnCollisionEnter2D(Collision2D collision) {

		if (collision.gameObject.tag == "Floor") {
			jumping = false;
			isGrounded = true; 
		}
			
		if (collision.collider.gameObject.name == "Barrel" && !isDead) {

			isDead = true;
			Destroy (gameObject);

			// Set Mario's velocity to 0, and increase his mass so that the barrels can't push him around :)
			rb.velocity = Vector2.zero;
			rb.mass = 1000;

			// Don't spawn any more barrels
			if (barrelSpawner != null) barrelSpawner.Stop();

			// Show the Game Over sprite
			if (gameOverSprite != null) gameOverSprite.enabled = true;
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {

		if (otherCollider.gameObject.name == "WinArea" && !hasWon) {
			
			hasWon = true;
			Destroy (goalItem);

			// Don't spawn any more barrels
			if (barrelSpawner != null) barrelSpawner.Stop();

			// Show the Win sprite
			if (winSprite != null) winSprite.enabled = true;
		}
	}

	public void moveLeft () {
		speed = -maxSpeed; 
	}

	public void moveRight() {
		speed = maxSpeed; 
	}

	public void Jump() {
		if (isGrounded) {
			jumping = true; 
			isGrounded = false;
			rb.AddForce (new Vector2(rb.velocity.x, jumpForce)); 
		}
	}

	public void stopMoving () {
		speed = 0; 
	}
}
