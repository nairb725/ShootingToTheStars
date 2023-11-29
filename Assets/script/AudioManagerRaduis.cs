using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerRaduis : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    // Update is called once per frame
    public void sound()
    {
        audioSource.Play();
    }
}
