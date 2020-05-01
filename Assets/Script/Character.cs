using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isHostile;
    public bool isPlayer;
    public bool isMoving;
    public float speed;
    public float damage;
    public float currentHealth;
    public float maxHealth;
    public float currentEnergy;
    public float maxEnergy;
    public Vector3 trajectory;
    protected Rigidbody2D rigidBody;
    protected Vector3 position;
    protected Vector3 previousPosition;

    void Update()
    {
        position = transform.position;
    }

    // Called after all Update methods have completed
    void LateUpdate()
    {
        // Update Previous Position
        previousPosition = position;
        
        // Check if character is moving
        if (position == previousPosition)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        // Update trajectory
        trajectory = GetTrajectory(transform, previousPosition);
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private Vector3 GetTrajectory(Transform target, Vector3 previousPosition)
    {
        return new Vector3(target.position.x - previousPosition.x, target.position.y - previousPosition.y).normalized;
    }
}
