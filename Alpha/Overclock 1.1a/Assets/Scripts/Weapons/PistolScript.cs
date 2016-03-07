using UnityEngine;
using System.Collections;

public class PistolScript: MonoBehaviour {

	public float fireRate = 0;
	public float damage = 10;
	public int clipSize = 6;
	public int currentClip;
	public float reloadTime = 2;
	public float critPerc = 20;
	public float critDmg = 1.5f;
	public LayerMask whatToHit;
	public Transform bulletPrefab;
	public Transform bulletSpawn;
	private bool reloading = false;
	private float critRNG;

	void Awake(){
		currentClip = clipSize;

	}

	void OnEnable(){
		reloading = false;
	}
	void Update () {
		if (Input.GetMouseButtonDown (0) && reloading == false) {
			if (currentClip > 0)
				Shoot ();
			else {
				StartCoroutine (Reload ());
				reloading = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.R) && currentClip != clipSize && reloading == false) {
			reloading = true;
			StartCoroutine (Reload ());
		}
	}

	IEnumerator Reload(){
		yield return new WaitForSeconds (reloadTime);
		currentClip = clipSize;
		Debug.Log ("Reloaded");
		reloading = false;
		StopCoroutine (Reload ());
	}
	void Shoot ()
	{
		critRNG = Random.value * 100;
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePosition = new Vector2 (bulletSpawn.position.x, bulletSpawn.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePosition, (mousePosition - firePosition), Mathf.Infinity, whatToHit);
		if (critRNG < critPerc) {
			Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
			damage *= critDmg;
		} else
		Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
		currentClip--;
		if (currentClip == 0) {
			reloading = true;
			StartCoroutine (Reload ());
		}
		if (hit.collider != null) {
			Debug.Log ("Hit " + hit.collider.name + " " + hit.collider.gameObject.tag);
			if (hit.collider.gameObject.tag == "Enemy") {
				Debug.Log ("Hit Enemy");
			}
		}
	}
}
