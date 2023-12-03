using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerEnnemies : MonoBehaviour
{
    [SerializeField]
    private GameManager KeepSpawning;

    [SerializeField]
    private Transform m_Tip;

    [SerializeField]
    private float m_Force;

    [SerializeField]
    private Rigidbody Prefab;

    [SerializeField]
    private float SpawnRate;


    [SerializeField]
    private bool spawnBool;

    void Start()
    {
        KeepSpawning = FindObjectOfType<GameManager>();
        spawnBool = true;
        InvokeRepeating("SpawnEnnemies", 5.0f, SpawnRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KeepSpawning.isPlaying() == false){
            spawnBool = false;
        }
    }

    void SpawnEnnemies()
    {
        if (spawnBool == true)
        {
            //get block and change color
            Rigidbody rigBod = Instantiate(Prefab, m_Tip.position, Quaternion.identity); //TODO Instantiate and setup
            rigBod.AddForce(m_Tip.forward * m_Force, ForceMode.Impulse); //Launch it
        }
    }

}
