using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//main menu 

public class MainMenu : MonoBehaviour
{
    public void GameStart(){
        SceneManager.LoadScene("CharacterSelection");
    }
}
