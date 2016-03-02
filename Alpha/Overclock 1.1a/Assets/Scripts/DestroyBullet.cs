using UnityEngine;
using System.Collections;



public class DestroyBullet : MonoBehaviour {

	private GameObject Player;
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * 80);
		Destroy (gameObject, 10);




	
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") {
			Debug.Log (".");
			Destroy (gameObject);
		}
	}
}