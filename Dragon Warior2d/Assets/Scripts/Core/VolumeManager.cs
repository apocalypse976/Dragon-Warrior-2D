using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class VolumeManager : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] string volumeName;
    private AudioSource MusicSource;
    // Start is called before the first frame update
    private void Awake()
    {
        MusicSource = GetComponent<AudioSource>();
    }
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

    public void changevol()
    {
        MusicSource.volume= slider.value;
        save();
    }
    private void Load()
    {
        slider.value = PlayerPrefs.GetFloat(volumeName,1);
    }
    private void save()
    {
        PlayerPrefs.SetFloat(volumeName, slider.value);
    }
}
