using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Sculpture : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float soundPlayRange = 10f;
    [SerializeField] AudioClip sculptureSound;
    [SerializeField] AudioSource mainSound;
    bool flagCariier = false;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {

        float distanceToPlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if(distanceToPlayer <= soundPlayRange)
         {
            //print("distance check");
            flagCariier = true;
            if (!audioSource.isPlaying)
            {
                //print("playonShot");
                mainSound.Pause();
                audioSource.PlayOneShot(sculptureSound);
            }
         }
        else
         {
            if (flagCariier)
            {
                flagCariier = false;
                //print("greater distance");
                audioSource.Stop();

                if (!mainSound.isPlaying)
                {
                    mainSound.Play();
                }
            }
         }
             
    }
}
 