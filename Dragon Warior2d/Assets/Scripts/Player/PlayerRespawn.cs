using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
      private Transform Checkpoint;
     private Health playerhealth;
    private UImanager uimanager;
    [SerializeField] private AudioClip CheckpointSFX;

    private void Awake()
    {
        playerhealth= GetComponent<Health>();
        uimanager = FindAnyObjectByType<UImanager>();
    }
    public void checkrespawn()
    {
        playerhealth.Respawn();
        if (Checkpoint == null)
        {
            uimanager.Gameover();
            return;
        }
        transform.position = Checkpoint.position;


        Camera.main.GetComponent<CameraFollow>().movetonewroom(Checkpoint.parent); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "CheckPoint")
        {
            Checkpoint = collision.transform;
            collision.GetComponent<Animator>().SetTrigger("Active");
            collision.GetComponent<Collider2D>().enabled= false;
            SoundManager.instance.Audio(CheckpointSFX);
        }
    }
}
