using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss : MonoBehaviour 
{
	public GameObject projectile;
	public float projectileSpeed = 10f;
	public float health = 150f;
	public float shotsPerSecond = 0.3f;
	public int scoreValue = 500;

	private UIManager uiManager; 
	private Slider bossHealthSlider;

	private void Start()
	{
		uiManager = GameObject.Find ("UIManager").GetComponent<UIManager> (); 
		bossHealthSlider = GameObject.Find ("Slider").GetComponent<Slider> ();

		Debug.Log (bossHealthSlider);
	}

	private void Update()
	{
		float prob = shotsPerSecond * Time.deltaTime;
		if(Random.value < prob)
		{
			Fire ();
		}
	}

	private void Fire()
	{
		GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-projectileSpeed);
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		Projectile missile = collider.gameObject.GetComponent<Projectile>();

		if(missile)
		{ 
			health -= missile.GetDamage();
		
			bossHealthSlider.value = health;
			missile.Hit();
			if (health <= 0) {
				Die();
			}
		}
	}

	private void Die()
	{
		Destroy(gameObject);
		uiManager.bossDead.text = "You defeated the boss and got an item!";
		uiManager.GameOver ();
	}
}
