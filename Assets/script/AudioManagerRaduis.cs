using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerRaduis : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    public void sound()
    {
        audioSource.Play();
    }
}
