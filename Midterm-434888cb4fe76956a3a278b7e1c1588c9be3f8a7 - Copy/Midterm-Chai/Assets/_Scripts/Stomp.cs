using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Stomp : MonoBehaviour {
	
	public AudioClip enemyDeathSound;
	public float delay ;

	AudioSource audio;


	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		}

	void OnTriggerEnter2D (Collision2D col){
	
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Stomp");
			StartCoroutine ("DelayDeath");

			/*Instantiate (enemyDeathEffect, coll.transform.position, coll.transform.rotation);
			playerBody.velocity = new Vector2 (playerBody.velocity.x, bounceOnEnemy);*/
		}
	
	
	
	}

	IEnumerator DelayDeath(){
	
		audio.PlayOneShot (enemyDeathSound, 1.0f);
		yield return new WaitForSeconds (delay);
		Destroy (transform.parent.gameObject);
		Debug.Log ("Murdderrrrrrr");


	}



}