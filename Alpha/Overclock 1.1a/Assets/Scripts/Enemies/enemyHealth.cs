using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

	public GameObject enemies;
	public Image enemyHPFill;

	void Start () {
	}

	void Update () 
	{
	//	float moveBar = ((enemies.GetComponent<Enemies> ().EnemyStats.maxHealth - enemies.GetComponent<Enemies> ().EnemyStats.currentHealth) * -0.0113f);

	//	transform.localScale = new Vector2 (enemies.GetComponent<Enemies> ().EnemyStats.currentHealth / 100, 1);
	//	transform.position = new Vector2 (enemies.transform.position.x + moveBar, enemies.transform.position.y + 1.5f );
	}
}
