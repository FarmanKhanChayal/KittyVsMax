using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public Toggle toggle;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicControl()
    {
       if(toggle.isOn)
        {
            audioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;
        }
    }
}
