using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour
{
    [SerializeField]
    private float horizontalSpeed = 2.0F;
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
    }
}