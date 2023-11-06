using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledCounter : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            FindObjectOfType<GameManager>().AddKill();
        }
    }
}
