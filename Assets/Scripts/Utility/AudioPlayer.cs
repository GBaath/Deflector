using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClip;
    public void PlayAudio(int index,float volume)
    {
       audioSource.PlayOneShot(audioClip[index],volume);
    }
}
