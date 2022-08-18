using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathclawCollision : MonoBehaviour
{       
        //when deathclaw comes across object with player tag, it damages them.
        public void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            PlayerHealth.instance.Health();
            }
        }
}
