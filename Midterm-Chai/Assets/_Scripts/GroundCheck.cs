using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    private PC player; //gives access to the script

    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponentInParent<PC>(); //player controller script is in the parent 
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        player.isGrounded = true;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        player.isGrounded = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        player.isGrounded = false;
    }
}
// Script was a courtesy of Elaine Gomez's youtube channel.
