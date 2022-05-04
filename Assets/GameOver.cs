using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Game over screen

public class GameOver : MonoBehaviour
{

  public void Restart(){

      SceneManager.LoadScene("Menu");

  }
}
