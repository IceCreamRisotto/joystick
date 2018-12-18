using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {

    private bool jumping = false;//跳躍中
    private bool isGround = false;//在不在地板

    public float jumpHeight=1000f;
    private Rigidbody2D player;

    private void Awake()
    {
        player = GameObject.Find("chicken").GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Debug.Log(jumping);
        Debug.Log(isGround);
        SetJumpState();
        StateMachine();
    }

    public void Jump() {
        if (!isGround || player.velocity.y != 0) { return; }

        player.AddForce(Vector3.up*jumpHeight);

    }

    void SetJumpState() {
        if (player.velocity.y > 0.1) {
            isGround = false;
            jumping = true;
        } else if (jumping) {
            jumping = false;
        }
    }

    void StateMachine() {

    }

    private void OnCollisionEnter2D(Collision2D co)
    {
        if (co.gameObject.tag == "Ground" && co.contacts[0].normal ==Vector2.up) {
            isGround = true;
        }
    }
}
