using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float verticalSpeed;

    private CharacterController characterController;

    private Vector3 moveDirection;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;
        verticalSpeed = 0.0f;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // D�placement horizontal
        Vector3 forward = transform.forward * moveZ;
        Vector3 right = transform.right * moveX;

        moveDirection = forward + right;
        moveDirection.Normalize();

        if(Input.GetKeyDown(KeyCode.T))
        {
            
        }

        // Application de la gravit�
        if (characterController.isGrounded)
        {
            verticalSpeed = 0.0f;
        }
        else
        {
            verticalSpeed += Physics.gravity.y * Time.deltaTime;
        }

        // Gestion du saut
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            verticalSpeed = CalculateJumpVerticalSpeed();
        }

        // Application de la v�locit�
        moveDirection.y = verticalSpeed;
        characterController.Move(moveDirection * speed * Time.deltaTime);
    }

    float CalculateJumpVerticalSpeed()
    {
        return Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * 0.5f);
    }
}
