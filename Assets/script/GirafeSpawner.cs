using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirafeSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform m_Tip;

    [SerializeField]
    private float m_Force;

    [SerializeField]
    private Rigidbody Prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SpawnGirafe()
    {
        Rigidbody rigBod = Instantiate(Prefab, m_Tip.position, Quaternion.identity); // Instantiate and setup
        Vector3 launchDirection = Quaternion.Euler(0, Random.Range(-45f, 45f), 0) * m_Tip.forward; // Adjust the launch direction

        rigBod.AddForce(launchDirection * m_Force, ForceMode.Impulse); // Launch it   
    }
}