using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FireTrap : MonoBehaviour

{
    [SerializeField] private float Activatiion_delay;
    [SerializeField] private float Activatiion_Time;
    [SerializeField] private float Damage;
    [SerializeField] private AudioClip ActivateSound;
    private Animator Anim;
    private SpriteRenderer Sr;
    private Health playerHP;
    private bool triggered;
    private bool Activeated;


    private void Awake()
    {
        Anim = GetComponent<Animator>();
       Sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(playerHP != null && Activeated) 
        {
            playerHP.take_damage(Damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
         playerHP=collision.GetComponent<Health>();

            if (!triggered )
            {
                StartCoroutine(Activated_trap());
            }
            if (Activeated)
            {
                collision.GetComponent<Health>().take_damage(Damage);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHP = null;
        }
    }
    private IEnumerator Activated_trap()
    {
        triggered = true;
        Sr.color = Color.red;

        yield return new WaitForSeconds(Activatiion_delay);
        SoundManager.instance.Audio(ActivateSound);
        Anim.SetBool("On", true);
        Activeated = true;
        Sr.color = Color.white;

        yield return new WaitForSeconds(Activatiion_Time);
        Anim.SetBool("On", false);
        triggered = false;
        Activeated= false;
    }
}
