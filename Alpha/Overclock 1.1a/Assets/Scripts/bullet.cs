using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	private GameObject player;

	void OnCollisionEnter2D(Collision2D col)
	{
		Destroy (gameObject);
		if (col.gameObject.tag == "Player")
			player.GetComponent<Player> ().DamagePlayer (20);
			Destroy (gameObject);
	}
}
