using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemies : MonoBehaviour {

	public float currentHealth = 0;
	public float maxHealth = 100;
	public float armor = 0.0f;
	public float drop;
	public GameObject enemyHPFill;
	public GameObject root;


	void Start () {
		currentHealth = maxHealth;
	}

	public void TakeDamage (float damage)
	{
		currentHealth -= damage * (1.00f - (0.01f * armor));
		if (currentHealth <= 0) 
		{
			Destroy (gameObject);
		}

	}


	void Update () {
		float moveBar = ((maxHealth - currentHealth) * -0.0113f);
		enemyHPFill.transform.localScale = new Vector2 (currentHealth / 100, 1);
		enemyHPFill.transform.position = new Vector2 (transform.position.x + moveBar, transform.position.y + 1);

	}
}
