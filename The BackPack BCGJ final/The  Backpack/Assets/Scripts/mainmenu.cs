using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour {

    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
        
    }

    // Update is called once per frame
    public void QuitGame() 
    {
        Debug.Log("QUIT!");
        Application.Quit();
        
    }

    public void Credits()
    {
        SceneManager.LoadScene("CREDITS");
    }
}
