﻿using UnityEngine;
using System.Collections;

public class BlasterScript : MonoBehaviour {

	public float damage = 10;
	public int clipSize = 12;
	public int currentClip;
	public float reloadTime = 2.5f;
	public float critPerc = 20;
	public float critDmg = 1.5f;
	private float shootInterval = 0.2f;

	public LayerMask whatToHit;
	public GameObject bulletPrefab;
	public GameObject critPrefab;
	public Transform bulletSpawn;
	private bool reloading = false;
	private float shootTimer;
	private float critRNG;




	void Awake(){
		currentClip = clipSize;
	}

	void OnEnable(){
		reloading = false;
	}

	void Update () {
		shootTimer += Time.deltaTime;
	if (Input.GetMouseButton (0) && reloading == false) {
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
	void Shoot(){
		if (shootTimer > shootInterval) {
			critRNG = Random.value * 100;
			shootTimer = 0;
			Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
			Vector2 firePosition = new Vector2 (bulletSpawn.position.x, bulletSpawn.position.y);
			RaycastHit2D hit = Physics2D.Raycast (firePosition, (mousePosition - firePosition), 1, whatToHit);
			if (critRNG < critPerc) {
				Instantiate (critPrefab, bulletSpawn.position, bulletSpawn.rotation);
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
			if (hit.collider.gameObject.tag == "Player") {
				Player p = hit.collider.GetComponent<Player> ();
				if (p != null) {
					Debug.Log ("Now it actually hit");
					p.DamagePlayer (10);
				}
			}
			//Debug.DrawLine (firePosition, hit.point, Color.red);
		}
	}
}
}