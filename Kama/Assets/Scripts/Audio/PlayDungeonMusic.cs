using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDungeonMusic : MonoBehaviour
{
    AudioSource audioSource;
    private AudioClip oldMusic;
    public AudioClip dungeonMusic;
    public Collider playerCollider;

    private void Start()
    {
        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();
        oldMusic = audioSource.clip;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider == playerCollider)
        {
            audioSource.clip = dungeonMusic;
            audioSource.volume = .5f;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider == playerCollider)
        {
            audioSource.clip = oldMusic;
            audioSource.volume = .5f;
            audioSource.Play();
        }
    }
}
