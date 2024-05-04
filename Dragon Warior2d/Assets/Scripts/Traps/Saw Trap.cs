using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class SawTrap : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float Movement_Distance;
    [SerializeField] private AudioClip SFX;
    private float leftedge;
    private float rightedge;
    private bool moveleft;

    // Start is called before the first frame update
    void Awake()
    {
        leftedge = transform.position.x - Movement_Distance;
        rightedge= transform.position.x +   Movement_Distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveleft)
        {
            if (leftedge<transform.position.x)
            {
                transform.position = new Vector2(transform.position.x- speed* Time.deltaTime,transform.position.y);
            }
            else
            {
                moveleft = false;
            }
        }
        else
        {
            if (rightedge > transform.position.x)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            }

            else
            {
                moveleft = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Player")
        {
            collision.GetComponent<Health>().take_damage(damage);
        }
        SoundManager.instance.Audio(SFX);
    }
}
