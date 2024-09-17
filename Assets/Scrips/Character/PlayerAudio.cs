using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        AudioON();
    }
    private void AudioON()
    {
        if (audioSource == _playerInput.jumpInput) 
        {
            audioSource.Play();
        }
    }
}
