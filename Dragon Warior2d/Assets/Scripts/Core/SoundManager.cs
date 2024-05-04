using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] string volumeName;
    [SerializeField] Slider slider;
    public static SoundManager instance { get; private set; }
    private AudioSource soundSource;
   

    void Start()
    {
        if (!PlayerPrefs.HasKey(volumeName))
        {
            PlayerPrefs.GetFloat(volumeName, 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    private void Awake()
    {
        instance = this;
        soundSource = GetComponent<AudioSource>();
       
       
      
    }
    public void Audio(AudioClip Sound)
    {
        soundSource.PlayOneShot(Sound);
    }
   
 

    public void changeSoundvol()
    {
        soundSource.volume = slider.value;
        save();
    }
   
    private void Load()
    {
        slider.value = PlayerPrefs.GetFloat(volumeName, 1);
    }
    private void save()
    {
        PlayerPrefs.SetFloat(volumeName, slider.value);
    }

}
