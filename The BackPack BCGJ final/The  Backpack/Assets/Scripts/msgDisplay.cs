using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class msgDisplay : MonoBehaviour {
    //  public Transform other;
     public GameObject textToDisplay;
     public float seconds = 2.0f;
     
     void Start() {
         textToDisplay.SetActive(false);
     }
     void Update() {

     }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Player")
        {
            // textToDisplay.SetActive(true);
            StartCoroutine( ShowAndHide(textToDisplay, seconds) ); // 2 seconds
            Debug.Log("displaymessage");
        }
    }

    IEnumerator ShowAndHide( GameObject go, float delay ) {
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }
            
 }