using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyPickup : MonoBehaviour
{
    public int count = 1;

    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Collectable")){
            Debug.Log("Collected!");
            Destroy(collision.gameObject);
            LevelManager.instance.AddSupply(count);
        }
    }
}
