using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    public AudioClip soundExplosion;
    AudioSource myAudio;

    public static ExplosionSound instance;

    void Awake() {
        if (ExplosionSound.instance == null) {
            ExplosionSound.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlaySound() {
        myAudio.PlayOneShot(soundExplosion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
