using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUdioManagerErika : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    void Start()
    {
        audioSource.Play();
    }
}
