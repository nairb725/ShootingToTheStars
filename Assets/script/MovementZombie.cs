using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementZombie : MonoBehaviour
{    
    [SerializeField]
    private bool _isTargetPlayer;
    
    [SerializeField]
    private float moveSpeed = 10f;

    private Transform target;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (target == null)
        {
            // Find the player
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
           
                // Ajust position targeting the player
                Vector3 direction = (target.position - transform.position).normalized;

                // Apply force
                rb.AddForce(direction * moveSpeed);
        }
    }
}
