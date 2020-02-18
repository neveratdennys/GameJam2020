using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{

    GameObject player;
   // public Sprite notJumping;
  //  public Sprite jumping;
  //  SpriteRenderer sr;
    

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
     //   sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            player.GetComponent<BallMovement>().lastWas = 0;
            player.GetComponent<BallMovement>().isGrounded = true;
            player.GetComponent<BallMovement>().isLeftJumpGrounded = false;
            player.GetComponent<BallMovement>().isRightJumpGrounded = false;
         //   sr.sprite = notJumping;
        }
    }

    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.collider.tag == "Ground")
    //     {
    //         player.GetComponent<BallMovement>().lastWas = 0;
    //         player.GetComponent<BallMovement>().isGrounded = false;
    //         player.GetComponent<BallMovement>().isLeftJumpGrounded = false;
    //         player.GetComponent<BallMovement>().isRightJumpGrounded = false;
    //     }
    // }
}
