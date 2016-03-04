using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour {
	[SerializeField] private GameObject textDisplay;
	private float timer = 0;
	private bool goToRestArea = false;
	private bool goToLevel2 = false;
	private bool startTimer = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startTimer == true)
			timer += Time.deltaTime;
		if (timer >= 2 && goToRestArea == true)
			SceneManager.LoadScene ("Rest Area");
		if (timer >= 2 && goToLevel2 == true)
			SceneManager.LoadScene ("Level2");
	}
		
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (Input.GetKeyDown (KeyCode.T) && SceneManager.GetActiveScene().name=="Level1") {
				Debug.Log ("Pressed T");
				goToRestArea = true;
				startTimer = true;
			}
			if (Input.GetKeyDown (KeyCode.Y)) {
				Debug.Log ("Pressed Y");
				goToLevel2 = true;
				startTimer = true;
			}
		}
	}
	void OnCollisionEnter2D (Collision2D col) {
	if (col.gameObject.tag == "Player") 
			textDisplay.SetActive (true);
	}
	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.tag == "Player") 
			textDisplay.SetActive (false);
	}
}