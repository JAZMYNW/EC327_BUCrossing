using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//randomly generates coins and detects collision

public class Coin : MonoBehaviour
{

    void OnCollisionEnter(Collision collision){

        if(collision.collider.tag == "Player"){
            Debug.Log("coin");
            for(int i = 0; i < 5; i++){
                ScoreManagment.instance.AddPoint();
            }
            Destroy(this.gameObject);
        }
    }
}
