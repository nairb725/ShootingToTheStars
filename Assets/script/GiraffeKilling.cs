using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraffeKilling : MonoBehaviour
{

    private Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.CompareTag("Ennemies"))
        {   
            Destroy(Collision.gameObject);
        }
    }
}
