using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControll : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip mySoundClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.clip = mySoundClip;
            audioSource.Play();
        }
    }
}
