using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  private Transform playerTransform;
  // forward edge limit
  private float fwdLim = 4;
  // backward edge limit
  private float bckLim = 5.5f;
  // upper edge limit
  private float upLim = 2;
  // lower edge limit
  private float downLim = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
      playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
      // current camera position
      Vector3 temp = transform.position;

      // horizontal off-screen check
      if (playerTransform.position.x > temp.x + fwdLim) {
        temp.x = playerTransform.position.x - fwdLim;
      } else if (playerTransform.position.x < temp.x - bckLim) {
        temp.x = playerTransform.position.x + bckLim;
      }

      // vertical off-screen check
      if (playerTransform.position.y > temp.y + upLim) {
        temp.y = playerTransform.position.y - upLim;
      } else if (playerTransform.position.y < temp.y - downLim) {
        temp.y = playerTransform.position.y + downLim;
      }

      // set temp to be camera's current pos
      transform.position = temp;

    }
}
