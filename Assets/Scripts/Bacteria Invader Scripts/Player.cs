using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	[SerializeField] private GameObject laser;
	[SerializeField] private float projectileSpeed = 10;
	[SerializeField] private float projectileRepeatRate = 0.2f;

	[SerializeField] private float speed = 15.0f;
	[SerializeField] private float health = 200;

	private float padding = 1;
	private float xmax = -5;
	private float xmin = 5;

	private UIManager uiManager; 

	private void Start()
	{
		uiManager = GameObject.Find ("UIManager").GetComponent<UIManager> ();
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		xmin = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x + padding;
		xmax = camera.ViewportToWorldPoint(new Vector3(1,1,distance)).x - padding;
	}

	private void Fire()
	{
		GameObject beam = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
	}

	private void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			InvokeRepeating("Fire", 0.0001f, projectileRepeatRate);
		}
		if(Input.GetKeyUp(KeyCode.Space))
		{
			CancelInvoke("Fire");
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x - speed * Time.deltaTime, xmin, xmax), transform.position.y, transform.position.z 
			);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x + speed * Time.deltaTime, xmin, xmax),transform.position.y, transform.position.z 
			);
		}
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
	
	private void Die()
	{
		Destroy(gameObject);
		uiManager.bossDead.text = "You didn't defeat the boss";
		uiManager.GameOver ();

	
	}
}
