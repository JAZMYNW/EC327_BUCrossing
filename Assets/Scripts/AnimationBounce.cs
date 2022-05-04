using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Animation for character
public class AnimationBounce : MonoBehaviour
{
    // Update is called once per frame
  void Update()
  {
    if(Input.GetButtonDown("right")){

      gameObject.transform.rotation = Quaternion.Euler(0,90,0);

    }
    if(Input.GetButtonDown("left")){
      
      gameObject.transform.rotation = Quaternion.Euler(0,-90,0);
      
    }
    if(Input.GetButtonDown("up")){

      gameObject.transform.rotation = Quaternion.Euler(0,0,0);

    }
    if(Input.GetButtonDown("down")){

      gameObject.transform.rotation = Quaternion.Euler(0,180,0);

    }
  }
}
