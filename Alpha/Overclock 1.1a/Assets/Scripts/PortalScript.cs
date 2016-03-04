using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour {

	private float timer = 0;
	private bool startTimer = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startTimer == true)
			timer += Time.deltaTime;
		if (timer >= 2)
			SceneManager.LoadScene ("Rest Area");
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (Input.GetKeyDown (KeyCode.T)) {
				Debug.Log ("t");
				startTimer = true;

			}
		}
	}
}
