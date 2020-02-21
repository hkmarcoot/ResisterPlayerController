using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTouchScreen : MonoBehaviour
{

    public Rigidbody2D theRB;
    public float moveSpeed;
    public Vector2 destination;
    public Vector2 place;
    public Vector2 journey;

    public Animator myAnim;

    // Use this for initialization
    void Start()
    {

        //Set the initial facing direction of the character
        myAnim.SetFloat("lastMoveX", 1);

        place = theRB.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            destination = Camera.main.ScreenToWorldPoint(touch.position);
            journey.x = destination.x - place.x;
            theRB.velocity = new Vector2(journey.normalized.x * Time.deltaTime, 0) * moveSpeed;
        }

        myAnim.SetFloat("moveX", theRB.velocity.x);

        //if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        //{
        //    myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
        //}

        if (journey.x >= 0.05)
        {
            myAnim.SetFloat("lastMoveX", 1);
        }
        else if (journey.x <= -0.05)
        {
            myAnim.SetFloat("lastMoveX", -1);
        }
    }

    private void LateUpdate()
    {
        place = theRB.transform.position;
        journey.x = destination.x - place.x;
        if (.05 > Mathf.Abs(journey.x))
        {
            theRB.velocity = new Vector2(0, 0);
        }
    }
}