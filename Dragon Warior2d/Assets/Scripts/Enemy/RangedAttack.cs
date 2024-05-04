using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
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


    [Header("Enemy Fireballs")]
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private Transform firepoint;

    [Header("Enemy Sound")]
    [SerializeField] private AudioClip RangedAttakSFX;

    //Referrences
    private Animator Anim; 
    private EnemyPatrolRA EnemyPatrol;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        Collider = GetComponent<CapsuleCollider2D>();
        EnemyPatrol = GetComponentInParent<EnemyPatrolRA>();
    }
    private void Update()
    {
        CoolDownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (AttackCoolDown < CoolDownTimer)
            {
                CoolDownTimer = 0;
                 Anim.SetTrigger("RangedAttack");
                SoundManager.instance.Audio(RangedAttakSFX);
            }
        }
        if (EnemyPatrol != null)
        {
            EnemyPatrol.enabled = !PlayerInSight();
        }

    }
    public void Rangedattack()
    {
        fireballs[FindFireballs()].transform.position = firepoint.position;
        fireballs[FindFireballs()].GetComponent<EnemyProjectile>().Activete_Time();
    }
    private int FindFireballs()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }return 0;
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(Collider.bounds.center + transform.right * Range * transform.localScale.x * Collider_Dis,
            new Vector2(Collider.bounds.size.x * Range, Collider.bounds.size.y),
           0, Vector2.right, 0, playerlayer);

        
        return hit.collider != null;
    }
   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Collider.bounds.center + transform.right * Range * transform.localScale.x * Collider_Dis,
            new Vector2(Collider.bounds.size.x * Range, Collider.bounds.size.y));
    }*/



}
