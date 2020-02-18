using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class horizontal_platform : MonoBehaviour
{
    Vector2 originalPosition; 
    bool switched = false; 

    [SerializeField]
    float vSpeed; 
    [SerializeField]
    float maxX; 


    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position; 
        vSpeed = 0.03f; 
        maxX = 5; 
    }

    // Update is called once per frame
    void Update()
    {
        changePosition(); 
    }

    void changePosition() {
        Vector2 temp = transform.position; 
        if (temp.x >= originalPosition.x + maxX) {
            temp.x = originalPosition.x + maxX; 
            temp.x = temp.x - vSpeed; 
            switched = true; 
        } 
        if (temp.x <= originalPosition.x - maxX) {
            temp.x = originalPosition.x - maxX; 
            temp.x = temp.x + vSpeed; 
            switched = false; 
        }
        if (temp.x < (originalPosition.x + maxX) && temp.x > (originalPosition.x - maxX)) {
            if (switched == true) {
                temp.x = temp.x - vSpeed;
            } 
            if (switched == false) {
                temp.x = temp.x + vSpeed;
            }
        }
        transform.position = temp; 

    }
}
