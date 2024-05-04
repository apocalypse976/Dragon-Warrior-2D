using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float Check_Delay;
    [SerializeField] private LayerMask PlayerLayer;
    [SerializeField] private AudioClip Sfx;
    private float Check_Timer;
    private Vector3 destination;
    private bool Attacking;
    private Vector3[] directons=new  Vector3[4];
  

    private void Update()
    {
        if (Attacking)
        {
            transform.Translate(destination*speed*Time.deltaTime);
        }
        else
        {
            Check_Timer += Time.deltaTime;
            if (Check_Timer > Check_Delay)
                 Check_for_players();
        }
    }
    private void OnEnable()
    {
        Stop();
    }
    private void Check_for_players()
    {
        Calculate_Directions();
        for(int i = 0; i < directons.Length; i++)
        {
            Debug.DrawRay(transform.position, directons[i], Color.red);
            RaycastHit2D raycast = Physics2D.Raycast(transform.position, directons[i],range,PlayerLayer);
            if (raycast.collider !=null&& !Attacking)
            {
                Check_Timer = 0;
                Attacking = true;
                destination = directons[i];
            }
        }
    }
    private void Calculate_Directions()
    {
        directons[0] = transform.right*range;
        directons[1]= -transform.right*range;
        directons[2]= transform.up*range;
        directons[3]= -transform.up*range;
    }
    private void Stop()
    {
         destination= transform.position ;
        Attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().take_damage(Damage);
        }
        SoundManager.instance.Audio(Sfx);
        Stop();

    }

}
