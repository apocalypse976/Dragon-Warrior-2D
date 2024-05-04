using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float AttackCoolDown;
    [SerializeField] private Transform Firepoint;
    [SerializeField] private GameObject[] FireBalls;
    [SerializeField] private float AttackButtonWait;
    [SerializeField] private AudioClip FireballSound;
    private float Cooldowntimer= Mathf.Infinity;
    private Player player;
    private Animator Anim;
    private Rigidbody2D rb;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Cooldowntimer += Time.deltaTime;
    }
    public void Attack()
    {
        IEnumerator Attack_time()
        {
            yield return new WaitForSeconds(AttackButtonWait);
            if (player.CanAttack() && Cooldowntimer > AttackCoolDown)
            {
                SoundManager.instance.Audio(FireballSound);
                Anim.SetTrigger("Attack");
                Cooldowntimer = 0;

                FireBalls[FindFireBalls()].transform.position = Firepoint.position;
                FireBalls[FindFireBalls()].GetComponent<Fireballs>().SetDirection(Mathf.Sign(transform.localScale.x));
            }
        }
        StartCoroutine (Attack_time());

    }
    private int FindFireBalls()
    {
        for (int i = 0; i<FireBalls.Length;i++)
        {
            if (!FireBalls[i].activeInHierarchy)
            
                return i;
        }
        return 0;
    }

}
