using UnityEngine;

public class RepulsionZone : MonoBehaviour
{
    [SerializeField]
    private float repulsionForce = 10f;

    [SerializeField]
    private float repulsionRadius = 5f;

    [SerializeField]
    private KeyCode activationKey = KeyCode.V;

    [SerializeField]
    private float repulsionDuration = 3f;

    private float repulsionTimer = 0f;

    void Update()
    {
        bool ReadyRaduisPropulsion = GameManager.Instance.RaduisPropuls;
        // if RaduisPropulsion is active do something
        if (ReadyRaduisPropulsion)
        {
            // Stock collider around
            Collider[] colliders = Physics.OverlapSphere(transform.position, repulsionRadius);

            // Apply force to each collider
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Bullet"))
                {
                    continue; // That will not affect bullets
                }

                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 direction = (collider.transform.position - transform.position).normalized;

                    // Provide error because position is {0,0,0}
                    float distance = Vector3.Distance(transform.position, collider.transform.position);
                    if (distance > 0f)
                    {
                        float repulsionStrength = repulsionForce / distance;
                        rb.AddForce(direction * repulsionStrength, ForceMode.Force);
                    }
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Show range in unity devtool
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, repulsionRadius);
    }
}
