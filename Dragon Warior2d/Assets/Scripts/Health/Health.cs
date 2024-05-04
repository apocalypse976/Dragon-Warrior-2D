using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float Starting_Health;
    public float Currenthealth { get; private set; }
    private bool dead;
    private Animator Anim;
    private SpriteRenderer sr;

    [Header("Iframes")]
    [SerializeField] private int SpawnProtection;
    [SerializeField] private int NumberofFlashes;

    [Header("Behaviours")]
    [SerializeField] private Behaviour[] Components;

    [Header("Sounds")]
    [SerializeField] private AudioClip HurtSound;
    [SerializeField] private AudioClip DeathSound;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        Currenthealth = Starting_Health;
    }
    public void take_damage(float Damage)
    {
        Currenthealth = Mathf.Clamp(Currenthealth - Damage, 0, Starting_Health);
        if (Currenthealth > 0)
        {

            SoundManager.instance.Audio(HurtSound);
            Anim.SetTrigger("Hurt");
            StartCoroutine(Spawn_protection());
        }
        else
        {
            if (!dead)
            {
                SoundManager.instance.Audio(DeathSound);
                foreach (Behaviour Componenet in Components)
                {
                    Componenet.enabled = false;
                }
                Anim.SetTrigger("Dead");

                

                dead = true;
                
            }

        }
    }
    public void AddHealth(float Health)
    {
        Currenthealth = Mathf.Clamp(Currenthealth + Health, 0, Starting_Health);
    }
    public void Respawn()
    {
        gameObject.SetActive(true);
        dead = false;
        AddHealth(Starting_Health);
        Anim.ResetTrigger("Dead");
        Anim.Play("Idle");
        StartCoroutine(Spawn_protection());
        foreach (Behaviour Componenet in Components)
        {
            Componenet.enabled = true;
        }

    }
    private IEnumerator Spawn_protection()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < NumberofFlashes; i++)
        {
            sr.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(SpawnProtection / (NumberofFlashes * 2));
            sr.color = Color.white;
            yield return new WaitForSeconds(SpawnProtection / (NumberofFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);


    }
    public void Deactivate()
    {
      
       
        StartCoroutine(Activeplayer());

    }
    IEnumerator Activeplayer()
    {
        gameObject.SetActive(false);
        if (!gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(1);
            gameObject.SetActive(true);
        }
    }
    public void DeactivateEnemy()
    {
        gameObject.SetActive(false);

    }
}
