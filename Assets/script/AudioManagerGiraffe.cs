using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerGiraffe : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    public void sound()
    {
        audioSource.Play();
    }
}
