using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballs : MonoBehaviour
{
    [SerializeField] private float Speed;
    private float LifeTime;
    private float Direction;
    private bool hit;

    private CircleCollider2D Collider;
    private Animator Anim;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        Collider = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float MovementSpeed = Speed * Time.deltaTime * Direction;
        transform.Translate(MovementSpeed, 0, 0);
        LifeTime += Time.deltaTime;
        if (LifeTime > 5)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        Collider.enabled = false;
        Anim.SetTrigger("Explode");

        
        if (collision.tag=="Enemy")
          collision. GetComponent<Health>().take_damage(1);
    }
    public void SetDirection(float _Direction)
    {
        LifeTime = 0;
        gameObject.SetActive (true);
        hit= false;
        Collider.enabled = true;
        Direction = _Direction;
        float LocalScaleX = transform.localScale.x;
        if (Mathf.Sign(LocalScaleX) != _Direction)
        
            LocalScaleX = -LocalScaleX;
        
        transform.localScale = new Vector3(LocalScaleX, transform.localScale.y, transform.localScale.z);


    }
    private void deactivate()
    {
        gameObject.SetActive(false);
    }
}




