using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
  public static int charnum;


  void Start(){

charnum = 0;

//Character Selection

}
  public void TurkeyButton(){
    charnum = 1;
      SceneManager.LoadScene("GamePlay");
  }
  public void RhettButton(){
      charnum = 2;
      SceneManager.LoadScene("GamePlay");
  }
  public void BCEagleButton(){
      charnum = 3;
      SceneManager.LoadScene("GamePlay");
  }
  public void NEUHuskyButton(){
        charnum = 4;
      SceneManager.LoadScene("GamePlay");
  }
  public void TuftsJumboButton(){
      charnum = 5;
      SceneManager.LoadScene("GamePlay");
  }
  public void ProfessorButton(){
      charnum = 6;
      SceneManager.LoadScene("GamePlay");
  }
}
