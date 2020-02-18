using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
     bullet = gameObject.transform.parent.gameObject;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Destroy(bullet);
        }
    } 

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Destroy(bullet);
        }
    }
}
