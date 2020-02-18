using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afterDie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e")) {
            RotateLeft(); 
        }
    }

    void RotateLeft() {
        transform.Rotate (Vector3.forward * -90);
        Vector2 temp = transform.position; 
        temp.y = transform.position.y - 83;  
        transform.position = temp; 
    }
}
