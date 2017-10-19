using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	private PC player;

	// use this for initialization
	void Start (){
	
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PC> ();
	
	}

	//update is called once per frame
	void OnCollisionEnter2d (Collider2D coll){

		if (coll.gameObject.tag == "Player") {
			
			player.hurt = true;
			player.Damage (1);
			//StartCoroutine (player.knockback (0.02f, 350, transform.position));
		} else {
		
			player.hurt = false;
		
		}
	}

	void OnCollisionExit2D (Collider2D coll){
	
		if (coll.gameObject.tag == "Player") {
		
			player.hurt = false;
			//StartCoroutine (player.
		}
	
	}


}
