using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
   
   
   /* [SerializeField]
    private float speed;
    private Vector3 Velocity = Vector3.zero;*/
    private float Currentpos;

    [SerializeField]private Transform player;


 
    private void Update()
    {
        // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Currentpos, transform.position.y, transform.position.z),
        //   ref Velocity, speed);
        transform.position = new Vector3(player.position.x,transform.position.y,transform.position.z);
    }
   public void movetonewroom(Transform NewRoom)
    {
        Currentpos = NewRoom.position.x;
    }
    
}
