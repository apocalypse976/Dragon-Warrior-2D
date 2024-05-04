using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private float speed;
    [SerializeField] private float ActiveTime;
    private Animator Anim;
    private BoxCollider2D Collider;
    private bool hit;
   
   

    private void Awake()
    {
        Anim= GetComponent<Animator>();
     Collider=GetComponent<BoxCollider2D>();

    }
    public void Activete_Time()
    {
     
        hit=false;
        gameObject.SetActive(true);
        Collider.enabled = true;
    }
    private void Update()
    {
        if (hit)  return; 
        float MovementSpeed = speed * Time.deltaTime;
        transform.Translate(MovementSpeed, 0, 0);
        StartCoroutine(Activetime());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      hit= true;

        if (collision.tag=="Player")
        {
            collision.GetComponent<Health>().take_damage(Damage);
        }
        Collider.enabled = false;


        if (Anim != null)
            Anim.SetTrigger("Explode");
        else
            gameObject.SetActive(false);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
        
    }
    IEnumerator Activetime()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        gameObject.SetActive(true) ;
    }




}
