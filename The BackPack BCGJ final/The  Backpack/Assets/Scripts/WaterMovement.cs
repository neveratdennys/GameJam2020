using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
  public float speed = 5;
  public float jump = 150;

  private float move;
  private Rigidbody2D rb;

      // For Jump Animations
    public Sprite notJumping;
    public Sprite jumping;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      move = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(move * speed, rb.velocity.y);
      if (Input.GetButtonDown("Jump")) {
        rb.AddForce(new Vector2(rb.velocity.x, jump));
        StartCoroutine( ShowAndHide(0.5f) );
      } 
    }

    IEnumerator ShowAndHide(float delay ) {
        sr.sprite = jumping;
        yield return new WaitForSeconds(delay);
        sr.sprite = notJumping;
    }
}
