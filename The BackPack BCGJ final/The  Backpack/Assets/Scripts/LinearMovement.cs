using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
	// Used to extrat player coord
	Transform playerTransform;
	
	[SerializeField]
	GameObject bullet;

	//
	public float fireRate;
	float nextFire;

    // Start is called before the first frame update
    void Start()
    {
	    playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	    fireRate = 1;
	    nextFire = Time.time;

        
    }

    // Update is called once per frame
    void Update()
    {
	    CheckIfTimeToFire(); 

    }

		
    void CheckIfTimeToFire()
    {
	    

	    
	    if(Time.time > nextFire)
	    {
		    //    failed attempt on log of player Y
		    /*double casterD = (double) playerTransform.position.y;
		    float casterF = (float) casterD/10;
		    fireRate = casterF;
		    */
		    if (fireRate > 0.35) {
				double caster = (double) fireRate/1.5;
		    	float caster2 = (float) caster;
		    	fireRate = caster2; 
			}

		     
		    Instantiate (bullet, transform.position, Quaternion.identity);
		    nextFire = Time.time + fireRate;
	    }
    }

    
}
