using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Loads Scene 1 [Game_Scene]
    public void PlayGame(){
        SceneManager.LoadScene(1);
    }
    
    public void QuitGame(){
        //Application.Quit();
    }

}//end MainMenu
