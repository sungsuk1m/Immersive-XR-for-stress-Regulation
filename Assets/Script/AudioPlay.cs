using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

[RequireComponent(typeof(AudioSource))]
public class AudioPlay : MonoBehaviour
{

    public StressLevel stressLevel;

    [Tooltip("Loop the currently playing sound")]
    public bool shouldLoop = false;

    [Tooltip("The list of audio clips to play from")]
    public List<AudioClip> audioClips = new List<AudioClip>();

    private AudioSource audioSource = null;
    private int index = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBasedOnStress(bool isPlaying)
    {
        if (isPlaying)
        {
            if (stressLevel.stressLevel < 30)
            {
                index = 0;
                PlayClip();
            }
            else if (stressLevel.stressLevel < 60)
            {
                index = 1;
                PlayClip();
            }
            else
            {
                index = 2;
                PlayClip();
            }
        }
        else {
            StopClip();
        }
    }
    public void NextClip()
    {
        index = ++index % audioClips.Count;
        PlayClip();
    }

    public void PreviousClip()
    {
        index = --index % audioClips.Count;
        PlayClip();
    }

    public void RandomClip()
    {
        index = Random.Range(0, audioClips.Count);
        PlayClip();
    }

    public void PlayAtIndex(int value)
    {
        index = Mathf.Clamp(value, 0, audioClips.Count);
        PlayClip();
    }

    public void PauseClip()
    {
        audioSource.Pause();
    }

    public void StopClip()
    {
        audioSource.Stop();
    }

    public void PlayCurrentClip()
    {
        PlayClip();
    }

    private void PlayClip()
    {
        audioSource.clip = audioClips[Mathf.Abs(index)];
        audioSource.Play();
    }

    private void OnValidate()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.loop = shouldLoop;
    }
}
