using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class EnemyPatrolRA : MonoBehaviour
{
    [Header("Enemy Position")]
    [SerializeField] private Transform Leftpos;
    [SerializeField] private Transform Rightpos;

    [Header("Enemy Attributes")]
    [SerializeField] private Transform Enemy;
    [SerializeField] private float speed;
    [SerializeField] private int Direction;

    [Header("Enemy Referrance")]
    [SerializeField] private Animator Animation;
    [SerializeField] private float idleDuration;
    private float idletimer;

    private Vector2 initScale;
    private bool Moveleft;

    private void Awake()
    {
        initScale = Enemy.localScale;
    }
    private void Update()
    {
        if (Moveleft)
        {

            if (Enemy.position.x >= Leftpos.position.x)
            {
                MoveingDirection(-Direction);
            }
            else
            {
                ChangeDirection();
            }
        }
        else
        {

            if (Enemy.position.x <= Rightpos.position.x)
            {
                MoveingDirection(Direction);
            }
            else
            {
                ChangeDirection();
            }
        }
    }
    private void OnDisable()
    {
        Animation.SetBool("Walk", false);
    }
    private void ChangeDirection()
    {
        Animation.SetBool("Walk",false);
        idletimer += Time.deltaTime;

        if (idletimer > idleDuration)
        {
            Moveleft =! Moveleft;
        }
    }
    void MoveingDirection(int _Direction)
    {
        Animation.SetBool("Walk", true);
        idletimer = 0;
        Enemy.localScale = new Vector2(Mathf.Abs (initScale.x)*_Direction,initScale.y);
        Enemy.position= new Vector2(Enemy.position.x+ Time.deltaTime*_Direction*speed,Enemy.position.y);
    }
}
