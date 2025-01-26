using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musichandling : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource SFX;

    public AudioClip BG;
    public AudioClip Boss;
    public AudioClip Bosshalf;

    private void Start()
    {
        music.clip = BG;
        music.loop = true;
        music.Play();
    }

    public void Playmusic(AudioClip clip)
    {
        music.Stop();
        music.PlayOneShot(clip);
    }
}
