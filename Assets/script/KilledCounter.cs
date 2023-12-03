using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledCounter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            FindObjectOfType<GameManager>().AddKill();
        }
    }
}
