using UnityEngine;
using System.Collections;

public class DroneAnim : MonoBehaviour {
	[SerializeField] private float fallSpeed = 1.0f;
	// Use this for initialization
	void Start () {
		StartCoroutine (killSelf ());
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (fallSpeed * Vector3.down * Time.deltaTime);
	
	}

	IEnumerator killSelf(){
		yield return new WaitForSeconds (1.1f);
		Destroy (this.gameObject);
	}
}
