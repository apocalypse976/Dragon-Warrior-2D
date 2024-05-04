using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinnerCheckPoint : MonoBehaviour
{
     private Animator Anim;
    [SerializeField] private GameObject WinnerScreen;
    [SerializeField] private AudioClip WinnerSound;
    
    [SerializeField] private GameObject[] Enemies;



    private void Awake()
    {
        Anim = GetComponent<Animator>();
        WinnerScreen.SetActive(false);
    }
    private bool EnemyActive()
    {
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (Enemies[i].activeInHierarchy)
            {
               return true;
            }
        } return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&& !EnemyActive())
        {
            Physics2D.IgnoreLayerCollision(10, 11);
            Anim.SetTrigger("Winner");
            SoundManager.instance.Audio(WinnerSound);
             StartCoroutine(SetActive());
            
        }
    }
    IEnumerator SetActive()
    {
        yield return new WaitForSeconds(5);
        Time.timeScale = 0;
        WinnerScreen.SetActive(true);
    }
}
