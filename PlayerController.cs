using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D theRB;
    public float moveSpeed;

    public Animator myAnim;

	// Use this for initialization
	void Start () {

        //Set the initial facing direction of the character
        myAnim.SetFloat("lastMoveX", 1);
    }
	
	// Update is called once per frame
	void Update () {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * moveSpeed;

        myAnim.SetFloat("moveX", theRB.velocity.x);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
        }
	}
}
