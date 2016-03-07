using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {
	[System.Serializable]
	public class enemyStats
	{
		public float currentHealth = 0;
		public float maxHealth = 100;
		public float armor = 0.0f;
		public float drop;
	}

	public enemyStats EnemyStats = new enemyStats();

	void Start () {
		EnemyStats.currentHealth = EnemyStats.maxHealth;
	}

	public void DamageEnemies (float damage)
	{
		EnemyStats.currentHealth -= damage * (1.00f - (0.01f * EnemyStats.armor));
		if (EnemyStats.currentHealth <= 0) 
		{
			Destroy (gameObject);
		}

	}


	void Update () {
	
	}
}
