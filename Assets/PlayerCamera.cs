using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;

    void start(){
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
   private void FixedUpdate()
   {
    //    transform.position = target.position;
    Vector3 temp = transform.position;
    temp.x = target.position.x;
    transform.position = temp;
   } 
    
}
