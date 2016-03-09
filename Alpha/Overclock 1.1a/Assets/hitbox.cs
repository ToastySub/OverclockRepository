using UnityEngine;
using System.Collections;

public class hitbox : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
			Debug.Log ("Outch!"); 
	}
}