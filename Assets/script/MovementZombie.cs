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
            // Trouver le joueur dans la sc�ne s'il n'est pas sp�cifi�
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
           
                // Calculer la direction vers le joueur
                Vector3 direction = (target.position - transform.position).normalized;

                // Appliquer une force dans la direction calcul�e
                rb.AddForce(direction * moveSpeed);
        }
    }
}
