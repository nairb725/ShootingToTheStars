using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementZombie : MonoBehaviour
{    
    [SerializeField]
    private float moveSpeed; // Speed at which the enemy moves
    [SerializeField]
    private bool _isTargetPlayer;

    void Update()
    {
        GameObject target = GameManager.Instance.DefineTarget();
        bool follow = GameManager.Instance.FollowOrNo;

        if (target != null)
        {
            if(follow == true)
            {
                // Calculate the direction from the enemy to the player
                Vector3 direction = target.transform.position + transform.position;

                // Normalize the direction vector
                direction.Normalize();

                // Move the enemy towards the player
                transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
            } else
            {
                // Calculate the direction from the enemy to the player
                Vector3 direction = target.transform.position - transform.position;

                // Normalize the direction vector
                direction.Normalize();

                // Move the enemy towards the player
                transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
