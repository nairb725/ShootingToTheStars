using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    private Rigidbody _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Player"){
            GameObject obj = GameObject.Find("Main Camera");
            obj.transform.parent = null;
            Destroy(GameObject.FindWithTag("Player"));
            GameManager.Instance.GameOver();
        }
    }
}
