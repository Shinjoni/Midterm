﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	private PlayerControl player;

	// use this for initialization
	void Start (){
	
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
	
	}

	//update is called once per frame
	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.tag == "Player") {

			player.hurt = true;
			player.Damage (1);

		} else {
		
			player.hurt = false;
		
		}
	}

	void OnTriggerExit2D (Collider2D other){
	
		if (other.gameObject.tag == "Player") {
		
			player.hurt = false;
		}
	
	}


}