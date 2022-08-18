using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // allows to change UI sprites

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public static PlayerHealth instance;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Transform playerHeight;
    public GameObject player;
    public GameObject gameOverScreen;
    public GameObject endScreen;
    public GameObject pauseMenu;

    public static bool gameIsPaused = false;

    //when player collides with an enemy, health bar goes down by 1.
    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Enemy")){
            Debug.Log("Hit!");
            health--;
            Debug.Log("Health value:" + health);
        }
    }

   

    //When player collides with collectable, collectable object is destroyed
    //and supply counter is incrememnted by 1.
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Collectable")){
            Debug.Log("Collected!");
            Destroy(collision.gameObject);
            LevelManager.instance.AddSupply(1);
        }
    }//end OnTriggerEnter2D

    void Awake(){
        instance = this;
    }
    
    // Update is called once per frame
    void Update()
    {   
        Time.timeScale = 1f;
        //if player falls off map, game over screen is called.
        if(player.transform.position.y < -10){
            Debug.Log("You died!");
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;

        }

        //if player reaches the end of the level, end screen is called.
        if (player.transform.position.x >= 207){
            endScreen.SetActive(true);
            Time.timeScale = 0f;
        }

        //prevents player from having more health that hearts displayed on screen
        if (health > numOfHearts){
            health = numOfHearts;
        }


        for (int i = 0; i < hearts.Length; i++){
            if (i < health){
                hearts[i].sprite = fullHeart;
            }else{
                hearts[i].sprite = emptyHeart;
            }
            
            //If statement controls the number of hearts displayed on screen
            if (i < numOfHearts){
                hearts[i].enabled = true;
            }else{
                hearts[i].enabled = false;
            }

            //if health falls to or below 0, Game over screen is displayed.
            if(health <= 0)
            {
                //activates Game over screen object
                gameOverScreen.SetActive(true);
                //freeze game so player can't move during game over screen
                Time.timeScale = 0f;
            }
        }
        //when user presses escape key, paue menu appears
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (gameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }//end update

    public void Health(){
        health--;
    }

    
    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}//end PlayerHealth class
