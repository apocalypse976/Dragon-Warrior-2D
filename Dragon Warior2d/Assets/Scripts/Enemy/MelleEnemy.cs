using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleEnemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private float AttackCoolDown;
    [SerializeField] private float Range;
    [SerializeField] private float Damage;

    [Header("Enemy Colliders")]
    [SerializeField] private float Collider_Dis;
    private CapsuleCollider2D Collider;


    [Header("Enemy Layers")]
    [SerializeField] private LayerMask playerlayer;
    private float CoolDownTimer = Mathf.Infinity;

    [Header("Enemy Sound")]
    [SerializeField] private AudioClip MelleAttack;

    //Referrences
    private Animator Anim;
    private EnemyPatrolling EnemyPatrol;
    private Health PlayerHealth;


    private void Awake()
    {
        Anim=GetComponent<Animator>();
        Collider = GetComponent<CapsuleCollider2D>();
        EnemyPatrol=GetComponentInParent<EnemyPatrolling>();
    }
   
   
    private void Update()
    {
        CoolDownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (AttackCoolDown < CoolDownTimer)
            {
                CoolDownTimer = 0;
                SoundManager.instance.Audio(MelleAttack);
                Anim.SetTrigger("Attack");
            }
        }
        if (EnemyPatrol != null)
        {
            EnemyPatrol.enabled =! PlayerInSight();
        }

    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(Collider.bounds.center +transform.right*Range* transform.localScale.x* Collider_Dis,
            new Vector2(Collider.bounds.size.x * Range, Collider.bounds.size.y),
           0,Vector2.right,0,playerlayer);

        if (hit.collider != null)
        {
            PlayerHealth= hit.transform.GetComponent<Health>();
        }
        return hit.collider!=null;
    }
   /* private void OnDrawGizmos()
    {
        Gizmos.color= Color.red;
        Gizmos.DrawWireCube(Collider.bounds.center + transform.right * Range* transform.localScale.x* Collider_Dis,
            new Vector2(Collider.bounds.size.x * Range, Collider.bounds.size.y));
    }*/
    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            PlayerHealth.take_damage(Damage);
        }
    }
}
