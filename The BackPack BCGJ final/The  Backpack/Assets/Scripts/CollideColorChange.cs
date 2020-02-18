using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideColorChange : MonoBehaviour
{
    public Color nextColor = Color.black;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag.Equals("ActionBackground"))
        {
            //Get the renderer of the object so we can access the color
            rend = GetComponent<Renderer>();
            //Set the initial color (0f,0f,0f,0f)
            rend.material.color = nextColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Pill"))
        {
            Destroy(collider.gameObject);
            GameObject[] temp = GameObject.FindGameObjectsWithTag("ActionBackground");
            foreach (GameObject background in temp)
            {
                //get the renderer of object (all objects should be actionbackgrounds in this case)
                rend = background.GetComponent<Renderer>();
                nextColor.r += 0.4f;
                nextColor.g += 0.2f;
                nextColor.b += 0.2f;
                rend.material.color = nextColor;
                Debug.Log("Brightened!");
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
