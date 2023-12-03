using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBullet : MonoBehaviour
{
    Renderer BulletColor;

    private Rigidbody _rigidBody;



    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if (Input.GetMouseButton(0))
        {
            BulletColor = GetComponent<Renderer>();
            BulletColor.material.SetColor("_EmissionColor", (new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f))));
            BulletColor.material.SetColor("_Color", (new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f))));
            ;
        }
        if (Collision.gameObject.CompareTag("Ennemies"))
        {   
            Destroy(Collision.gameObject);
        }
        else{
            Destroy(gameObject, 1);
        }
    }
}
