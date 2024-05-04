using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField]
    private Transform nextroom;
    [SerializeField]
    private Transform previousroom;
    [SerializeField]
    private CameraFollow cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.movetonewroom(nextroom);
            }
            else
            {
                cam.movetonewroom(previousroom);
            }
        }
    }
}
