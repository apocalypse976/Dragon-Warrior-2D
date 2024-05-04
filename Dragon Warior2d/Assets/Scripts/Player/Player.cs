using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Vector2 move;
    private float wallJumpCoolDown;

    public FixedJoystick joystick;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator Anim;
    private CapsuleCollider2D CC;
    
    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask WallLayer;

    [Header("Audio")]
    [SerializeField] private AudioClip jumpSound;


    void Awake()
    {
       
       spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Anim= GetComponent<Animator>();
        CC = GetComponent<CapsuleCollider2D>();
        
    }

 
    void Update()
    {
      
        move.x = joystick.Horizontal;
       

        //fliping player
        if (move.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (move.x > 0)
        {
            transform.localScale =  Vector3.one;
        }
        //Player Animation
        Anim.SetBool("Walk", move.x!=0);
        Anim.SetBool("Grounded", isGrounded());

    //Wall Jump
    if (wallJumpCoolDown > 0.1f)
        {
            rb.MovePosition(rb.position + move * speed * Time.deltaTime);
            if (onwall()&& !isGrounded())
            {
                rb.gravityScale = 0;
                rb.velocity= Vector2.zero;
            }
            else
            {
                rb.gravityScale=10;
            }
         }
        else
        {
            wallJumpCoolDown += Time.deltaTime;
        }
    }
    public void jumpbutton()
    {
      
        if (isGrounded())
        {
            SoundManager.instance.Audio(jumpSound);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Anim.SetTrigger("Jump");
        }
        else if (onwall() && !isGrounded())
        {
            if (move.x == 0)
            {
                spriteRenderer.flipX = false;
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCoolDown = 0;
        }

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast( CC.bounds.center,CC.bounds.size,0,Vector2.down,0.1f,groundLayer);
        return raycastHit.collider!=null;   
    }
    private bool onwall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(CC.bounds.center, CC.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, WallLayer);
        return raycastHit.collider != null;
    }
    public bool CanAttack()
    {
        return isGrounded() && !onwall()&& move.x==0;
    }
}
