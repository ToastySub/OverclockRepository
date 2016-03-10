using UnityEngine;
using System.Collections;

public class bullMove : MonoBehaviour
{
	void OnCollisionEnter2D (Collision2D c)
	{
		if (!(c.gameObject.tag == "Enemy"))
		{
			GameObject.Destroy (this.gameObject);
		}
	}
}
