using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange2 : MonoBehaviour {
	private PC player;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			SceneManager.LoadScene ("Level2");
		}
	}
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PC> ();
	}

	// Update is called once per frame
	void Update () {

	}
}
// Script was a courtesy of Elaine Gomez's youtube channel.
