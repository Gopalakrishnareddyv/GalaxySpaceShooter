using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip explosionClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = explosionClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
