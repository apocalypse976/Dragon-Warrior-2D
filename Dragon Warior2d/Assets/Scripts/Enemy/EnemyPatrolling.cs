using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    [Header("Enemy Patrolling")]
    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;

    [Header("Enemy Atrributes")]
    [SerializeField] private Transform Enemy;
    [SerializeField] private float speed;
    [SerializeField] private int Direction;

    private bool moveleft;
    private Vector3 initScale;

    [Header("References")]
    [SerializeField] private Animator Anim;
    [SerializeField] private float idleDuration;
    private float idletimer;

    private void Awake()
    {
        initScale = Enemy.localScale;
    }
    private void Update()
    {
        if (moveleft)
        {
            if (Enemy.position.x >= leftPos.position.x)
            {
                Moving_Direction(-Direction);
            }
            else
            {
                Change_Direction();
            }
        }
        else
        {
            if (Enemy.position.x <= rightPos.position.x)
            {
                Moving_Direction(Direction);
            }
            else
            {
                Change_Direction();
            }
        }
    }
     private void OnDisable()
    {
        Anim.SetBool("Walk", false);
    }
    void Change_Direction()
    {
        Anim.SetBool("Walk", false);
        idletimer += Time.deltaTime;
        if(idletimer > idleDuration) 
              moveleft =! moveleft;
    }
    private void Moving_Direction(int _direction )
    {
        idletimer = 0;
        Anim.SetBool("Walk", true);
        
       
        Enemy.localScale = new Vector3(MathF.Abs(initScale.x)*_direction, initScale.y, initScale.z);
        Enemy.position = new Vector3(Enemy.position.x +Time.deltaTime* _direction * speed,Enemy.position.y,Enemy.position.z);
    }
}
