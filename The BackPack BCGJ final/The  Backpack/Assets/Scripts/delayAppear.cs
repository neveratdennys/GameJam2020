using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayAppear : MonoBehaviour
{
    void Start() {

    } 

    void Update()
    { 
        if (Input.GetKeyDown("e")) {
            Destroy(gameObject);
        } 
        if (Time.time > 15) {
            Destroy(gameObject); 
        }
    }
}
