using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	[SerializeField] private GameObject projectile;
	[SerializeField] private float projectileSpeed = 10f;
	[SerializeField] private float health = 150f;
	[SerializeField] private float shotsPerSecond = 0.3f;
	[SerializeField] private int scoreValue = 100;
	
	private ScoreManager scoreManager; 
	
	private void Start()
	{
		scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
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
			missile.Hit();
			if (health <= 0) {
				Die();
			}
		}
	}
	
	private void Die()
	{
		scoreManager.Score (scoreValue);
		Destroy(gameObject);
	}
}
