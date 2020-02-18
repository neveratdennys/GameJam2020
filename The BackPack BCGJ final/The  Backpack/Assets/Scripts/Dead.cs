using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
	public Animator transition;
	public float transitionTime = 1f;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//Debug.Log("collision detected");
		if (col.gameObject.name.Equals ("Player")) {
			StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
		//Debug.Log("collision detected in if");
		}
	}

	IEnumerator LoadLevel(int levelIndex) {
		// play animation
		transition.SetTrigger("Start"); // failing here
		Debug.Log("hit load animation");
		// wait for animation to play
		yield return new WaitForSeconds(transitionTime);
		// load Scene
		SceneManager.LoadScene(levelIndex);
	}


}
