using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LinearBullet : MonoBehaviour
{
	float moveSpeed = 7f;
	float time; 

	Rigidbody2D rb;
	Vector2 moveDirection;
	//Platform floor;

    // Start is called before the first frame update
    void Start()
    {
	    time = Time.time;
	    rb = GetComponent<Rigidbody2D> ();
	    moveDirection = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
	    rb.velocity = new Vector2 (moveDirection.x, -1 * Math.Abs(moveDirection.y));
    }

    // Update is called once per frame
    void Update()
    {
       UpdateSpeed(); 
	   yDelete();
    }
    
    void UpdateSpeed() 
    {
	    double caster = (double) time;
	    float caster2 = (float) Math.Sqrt(1.5 * caster);
	    moveSpeed = moveSpeed + caster2;
    } 

	void yDelete() {
		if (gameObject.transform.position.y <= 0.3141592653 && gameObject.transform.position.y >= -6.0 || 
				gameObject.transform.position.y >=45) {
			Destroy(gameObject);
		}
	}
}