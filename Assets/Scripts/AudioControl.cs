using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    PlayerMovement player;

    public AudioSource jump;
    AudioSource audioSource;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }

   // public void PlayJumpSound()
    //{
      //  if (player.isGrounded && Input.GetKey(KeyCode.Space))
        //    audioSource.PlayOneShot(jump);
    //}
}
