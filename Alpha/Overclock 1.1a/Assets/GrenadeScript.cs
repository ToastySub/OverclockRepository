using UnityEngine;
using System.Collections;

public class GrenadeScript : MonoBehaviour {

	private Rigidbody2D myScriptsRigidbody2D;

	void Start () {
		myScriptsRigidbody2D = GetComponent<Rigidbody2D>();
		myScriptsRigidbody2D.AddForce(transform.right * 50);
	}
	
	void Update () {
		//myScriptsRigidbody2D.AddForce(transform.up * 1000);
		}
}