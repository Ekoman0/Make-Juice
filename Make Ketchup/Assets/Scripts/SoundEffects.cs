using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource Aus;

    public AudioClip[] FruitSoundClip;

    private float Timer;

    int WhichSound;

        private void Start()
        {
        Timer = Random.Range(10, 30);
        WhichSound = Random.Range(0,FruitSoundClip.Length);
        }

    private void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer<0)
        {
            Aus.clip = FruitSoundClip[WhichSound];

            Aus.Play();

            WhichSound = Random.Range(0, FruitSoundClip.Length);

            Timer = Random.Range(10, 30);

        }
    }
}
