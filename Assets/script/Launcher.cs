using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Launcher : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //get block and change color
            Rigidbody rigBod = Instantiate(Prefab, m_Tip.position, Quaternion.identity); //TODO Instantiate and setup
            rigBod.AddForce(m_Tip.forward * m_Force, ForceMode.Impulse); //Launch it
        }
    }
}
