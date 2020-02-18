using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class vertical_platform : MonoBehaviour
{
    Vector2 originalPosition; 
    bool switched = false; 

    [SerializeField]
    float vSpeed; 
    [SerializeField]
    float maxY;


    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position; 
        vSpeed = 0.04f; 
        maxY = 5; 
    }

    // Update is called once per frame
    void Update()
    {
        changePosition(); 
    }

    void changePosition() {
        Vector2 temp = transform.position; 
        if (temp.y >= originalPosition.y + maxY) {
            temp.y = originalPosition.y + maxY; 
            temp.y = temp.y - vSpeed; 
            switched = true; 
        } 
        if (temp.y <= originalPosition.y - maxY) {
            temp.y = originalPosition.y - maxY; 
            temp.y = temp.y + vSpeed; 
            switched = false; 
        }
        if (temp.y < (originalPosition.y + maxY) && temp.y > (originalPosition.y - maxY)) {
            if (switched == true) {
                temp.y = temp.y - vSpeed;
            } 
            if (switched == false) {
                temp.y = temp.y + vSpeed;
            }
        }
        transform.position = temp; 

    }
}
