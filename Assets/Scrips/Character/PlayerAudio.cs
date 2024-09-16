using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        AudioON();
    }
    private void AudioON()
    {
        if (audioSource == playerInput.jumpInput) 
        {
            audioSource.Play();
        }
    }
}
