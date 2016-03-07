using UnityEngine;
using System.Collections;



public class DestroyBullet : MonoBehaviour {
	public int speed;
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
		Destroy (gameObject, 10);




	
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") {
			Destroy (gameObject);
		}
	}
}