using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// moves camera

public class Cam : MonoBehaviour
{
public GameObject Player;

Vector3 campos;

void Update()
    {

  if(Player != null && Player.transform.position.z - gameObject.transform.position.z > 1){
    campos = Vector3.Lerp(gameObject.transform.position, Player.transform.position,0.09f);
    gameObject.transform.position = new Vector3(0,1,campos.z);
      }
  else {
    gameObject.transform.position = (gameObject.transform.position + new Vector3(0,0,Time.deltaTime * 0.5f));
      }

    }
}
