﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {

        SceneManager.LoadScene("Scripts (l2)");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
// Script was a courtesy of Elaine Gomez's youtube channel.
