using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip hitSound;
    public AudioClip endSound;
    public AudioClip gameOverSound;

    private Vector3 cameraPosition;

    void Awake()
    {
        Instance = this;
        cameraPosition = Camera.main.transform.position;
    }

    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }

    public void PlayHitSound()
    {
        PlaySound(hitSound);
    }

    public void PlayEndSound()
    {
        PlaySound(endSound);
    }

    public void PlayGameOverSound()
    {
        PlaySound(gameOverSound);
    }
}
