using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
  public float speed;
    public bool isRightJumpGrounded = false;
    public float lastWas; // 0 is initial, 1 is LEFT, 2 is RIGHT
    public bool isLeftJumpGrounded = false;
    public bool isGrounded = false;
    public float jumpHeight = 5f;

    // For Jump Animations
    public Sprite notJumping;
    public Sprite jumping;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        lastWas = 0;
        // init SpriteRenderer
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        sideJumpLeft();
        sideJumpRight();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        if (!isGrounded) {
            sr.sprite = jumping;
        } else {
            sr.sprite = notJumping;
        }
    }


    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true && isRightJumpGrounded == false && isLeftJumpGrounded == false)
        {
            lastWas = 0;
            isGrounded = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            // Animate jump
            // sr.sprite = jumping;
        }
    }
    
    void sideJumpRight()
    {
        if (Input.GetButtonDown("Jump") && isRightJumpGrounded == true && isLeftJumpGrounded == false && isGrounded == false && lastWas != 2)
        {
            lastWas = 2;
            isRightJumpGrounded = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
            // Animate jump
            // sr.sprite = jumping;
        }
    }

    void sideJumpLeft()
    {
        if (Input.GetButtonDown("Jump") && isLeftJumpGrounded == true && isRightJumpGrounded == false && isGrounded == false && lastWas != 1)
        {
            lastWas = 1;
            isLeftJumpGrounded = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
            // Animate jump
            // sr.sprite = jumping;
        }
    }
}
