using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public float movementSpeed;
    //Adds velocity and forces to our character
    public Rigidbody2D rb;

    public Animator anim;

    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;

    // private. controls movement on the x-axis
    float moveX;


    private void Update(){
        moveX = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump") && isGrounded()){
            Jump();
        }

        if (Mathf.Abs(moveX) > 0.05f)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        //flips character sprite when moving left
        if (moveX > 0.05f)
            transform.localScale = new Vector3(1f, 1f, 1f);
        if (moveX < 0f)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        anim.SetBool("isGrounded", isGrounded());    
        
    }




    private void FixedUpdate(){
        Vector2 movement = new Vector2(moveX * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    public void Jump(){
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }

    public bool isGrounded(){
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if(groundCheck != null){
            return true;

        }

        return false;
    }
}
