using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeeThrowTheWall : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private LayerMask obstacleLayer;

    [SerializeField]
    private float maxDistance = 2f;

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        RaycastHit hit;
        Debug.Log("no hitted a wall");
        if (Physics.Raycast(transform.position, direction, out hit, maxDistance, obstacleLayer))
        {
            Debug.Log("hitted a wall");
            // Ajuster la position de la caméra pour éviter le mur
            transform.position = hit.point;
        }
    }
}