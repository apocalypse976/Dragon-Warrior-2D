using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private GameObject [] Arrows;
    [SerializeField] private Transform ArrowPoint;
    [SerializeField] private float AttackCoolDown;
    [SerializeField] private AudioClip SFX;
    private float CooldownTimer;

    void Attack()
    {
        SoundManager.instance.Audio(SFX);
        CooldownTimer = 0;
        Arrows[FindArrows()].transform.position = ArrowPoint.position;
        Arrows[FindArrows()].GetComponent<EnemyProjectile>().Activete_Time();
    }
    private int FindArrows()
    {
        for (int i = 0; i < Arrows.Length; i++)
        {
            if (!Arrows[i].activeInHierarchy) 
            {
                return i;
            }
        } return 0;
    }
    private void Update()
    {
        CooldownTimer+= Time.deltaTime;
        if (CooldownTimer>=AttackCoolDown)
        {
            Attack();
        }
    }
}
