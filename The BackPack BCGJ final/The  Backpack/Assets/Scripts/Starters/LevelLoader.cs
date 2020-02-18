using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
  public Animator transition;
  public GameObject FinalDoor;
  public float transitionTime = 1f;

  public float doorDist = 1f;
  public float doorDistNew = 5f;

  // completed levels:
  private bool completed_1;
  private bool completed_2;
  private bool completed_3;

    // testing this
    void Awake() {
      //
    }

    // runs at start
    void Start() {

      //Debug.Log(test);
      load();
      if (SceneManager.GetActiveScene().buildIndex == 1) {
        FinalDoor = GameObject.FindGameObjectWithTag("FinalDoor");
        FinalDoor.SetActive(false);
        if (completed_1 && completed_2 && completed_3) {
          FinalDoor.SetActive(true);
        }
      }
      // Debug.Log(completed_1);
      // Debug.Log(completed_2);
      // Debug.Log(completed_3);
    }

    void Update() {
      if (Input.GetKeyDown("q")) {
        save();
      }
      if (Input.GetKeyDown("r")) {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
      }
      if (Input.GetKeyDown("n")) {
        newGame();
      }
      if (Input.GetKeyDown("1")) {
        StartCoroutine(LoadLevel(2));
      }
      if (Input.GetKeyDown("2")) {
        StartCoroutine(LoadLevel(3));
      }
      if (Input.GetKeyDown("3")) {
        StartCoroutine(LoadLevel(4));
      }
      if (Input.GetKeyDown("4")) {
        StartCoroutine(LoadLevel(5));
      }
      if (Input.GetKeyDown("escape")) {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
      }
    }

    // Update is called once per frame
    void LateUpdate()
    {
      float playerX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
      float playerY = GameObject.FindGameObjectWithTag("Player").transform.position.y;
      if (SceneManager.GetActiveScene().buildIndex == 1) {
        mainStage(playerX, playerY);
      } else if (completed_1 && completed_2 && completed_3) {
        finalStage(playerX, playerY);
      } else if (SceneManager.GetActiveScene().buildIndex <= 4 && SceneManager.GetActiveScene().buildIndex > 1) {
        bossStage(playerX, playerY);
      }
    }

    void mainStage(float playerX, float playerY) {
      // door to boss1
      float door1_X = GameObject.FindGameObjectWithTag("Door1").transform.position.x;
      float door1_Y = GameObject.FindGameObjectWithTag("Door1").transform.position.y;
      // door to boss2
      float door2_X = GameObject.FindGameObjectWithTag("Door2").transform.position.x;
      float door2_Y = GameObject.FindGameObjectWithTag("Door2").transform.position.y;
      // door to boss3
      float door3_X = GameObject.FindGameObjectWithTag("Door3").transform.position.x;
      float door3_Y = GameObject.FindGameObjectWithTag("Door3").transform.position.y;

      bool door1 = (Math.Abs(playerX - door1_X) < doorDistNew + 1f &&
                    Math.Abs(playerY - door1_Y) < doorDistNew);


      bool door2 = (Math.Abs(playerX - door2_X) < doorDistNew + 1&&
                    Math.Abs(playerY - door2_Y) < doorDistNew);

      bool door3 = (Math.Abs(playerX - door3_X) < doorDistNew &&
                    Math.Abs(playerY - door3_Y) < doorDistNew + 2);


      if (Input.GetKeyDown("e")) {
        if(door1) {
          StartCoroutine(LoadLevel(2));
        } else if (door2) {
          StartCoroutine(LoadLevel(3));
        } else if (door3) {
          StartCoroutine(LoadLevel(4));
        }
      }

      // checks for end of game
      if (completed_1 && completed_2 && completed_3) {
        // door to finalStage
        float doorFinal_X = GameObject.FindGameObjectWithTag("FinalDoor").transform.position.x;
        float doorFinal_Y = GameObject.FindGameObjectWithTag("FinalDoor").transform.position.y;

        bool doorFinal = (Math.Abs(playerX - doorFinal_X) < doorDist &&
                          Math.Abs(playerY - doorFinal_Y) < doorDist);

        if (doorFinal && FinalDoor.activeSelf) {
          StartCoroutine(LoadLevel(5));
        }
      }

    }

    void bossStage(float playerX, float playerY) {
      float door_X = GameObject.FindGameObjectWithTag("Door").transform.position.x;
      float door_Y = GameObject.FindGameObjectWithTag("Door").transform.position.y;

      bool door = (Math.Abs(playerX - door_X) < doorDist &&
                   Math.Abs(playerY - door_Y) < doorDist);

      if (Input.GetKeyDown("e") && door) {
        complete_Level(SceneManager.GetActiveScene().buildIndex - 1);
        StartCoroutine(LoadLevel(1));
      }
    }

    void finalStage(float playerX, float playerY) {
      float door_X = GameObject.FindGameObjectWithTag("Door").transform.position.x;
      float door_Y = GameObject.FindGameObjectWithTag("Door").transform.position.y;

      bool door = (Math.Abs(playerX - door_X) < doorDist &&
                   Math.Abs(playerY - door_Y) < doorDist);

      if (Input.GetKeyDown("e") && door) {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
      }
    }

    void complete_Level(int levelIndex) {
      if (levelIndex == 1) {
        //Debug.Log("completed 1");
        completed_1 = true;
      } else if (levelIndex == 2) {
        completed_2 = true;
      } else if (levelIndex == 3) {
        completed_3 = true;
      }
      save();
    }


    void save() {
      // save world
      PlayerPrefs.SetInt("currentScene", SceneManager.GetActiveScene().buildIndex);

      // save position
      Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
      PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
      PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);

      // save bools
      PlayerPrefs.SetString("completed_1", saveBool(completed_1));
      PlayerPrefs.SetString("completed_2", saveBool(completed_2));
      PlayerPrefs.SetString("completed_3", saveBool(completed_3));

      // save
      PlayerPrefs.Save();

      // bool test = loadBool(PlayerPrefs.GetString("completed_1"));
      // Debug.Log(test);
    }

    string saveBool(bool state) {
      if (state) {
        return "true";
      } else {
        return "false";
      }
    }

    bool loadBool(string state) {
      if (string.Equals(state, "true")) {
        return true;
      } else {
        return false;
      }
    }

    void load() {
      // load from Save
      completed_1 = loadBool(PlayerPrefs.GetString("completed_1"));
      completed_2 = loadBool(PlayerPrefs.GetString("completed_2"));
      completed_3 = loadBool(PlayerPrefs.GetString("completed_3"));
    }

    void newGame() {
      // save bools
      PlayerPrefs.SetString("completed_1", "false");
      PlayerPrefs.SetString("completed_2", "false");
      PlayerPrefs.SetString("completed_3", "false");

      // save
      PlayerPrefs.Save();

      StartCoroutine(LoadLevel(0));
    }


    IEnumerator LoadLevel(int levelIndex) {
      // play animation
      transition.SetTrigger("Start");
      // wait for animation to play
      yield return new WaitForSeconds(transitionTime);
      // load Scene
      SceneManager.LoadScene(levelIndex);
    }
}
