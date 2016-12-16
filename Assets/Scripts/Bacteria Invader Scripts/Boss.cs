using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour 
{
	[SerializeField] private GameObject projectile;
	[SerializeField] private float projectileSpeed = 10f;
	[SerializeField] private float health = 150f;
	[SerializeField] private float shotsPerSecond = 0.5f;
	[SerializeField] private int scoreValue = 150;

	private ScoreManager scoreManager; 
	private UIManager uiManager; 

	private void Start()
	{
		scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
		uiManager = GameObject.Find ("UIManager").GetComponent<UIManager> (); 
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

		uiManager.bossDead.text = "You defeated the boss and got an item!s";
		uiManager.GameOver ();
	}
}
