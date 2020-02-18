using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_floor : MonoBehaviour
{
    float drop; 
    // Start is called before the first frame update
    void Start()
    {
        drop = 100f; 
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "BottomDetect")
        {
           Vector2 temp = transform.position; 
           temp.y = transform.position.y - drop; 
           transform.position = temp; 
        }
    } 
}
