using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public TextMeshProUGUI stimpakCount;
    public TextMeshProUGUI deathScore;
    public TextMeshProUGUI endScreenScore;
    public GameObject gameOverScreen;

    //Changes header name in Unity Inspector
    [Header("Supplies")]
    public int supplyCount = 0;
    public static int counter;

    //when player collides with a collecatable, supplyCount += 1
    public void AddSupply(int amount){
        supplyCount += amount;
        counter = supplyCount;
        stimpakCount.text = "Score: " + supplyCount;

        deathScore.text = "Score: " + supplyCount;
        
        if(supplyCount == 7){
            supplyCount += 3;
            endScreenScore.text = "You got all stimpaks! \n Score: " + supplyCount;
        }else{
            endScreenScore.text = "Score: " + supplyCount;
        }
    }//end AddSupply

    private void Awake(){
        instance = this;
    }//end Awake

    //return to scene 1 (Game Scene)
    public void RetryButton(){
        SceneManager.LoadScene(1);
    }//end RetryButton

    //return to scene 0 (main menu)
    public void QuitButton(){
        SceneManager.LoadScene(0);
    }//end QuitButton

    public void QuitToDesktop(){
        Application.Quit();
    }//end QuitToDesktop


    
}//end class
