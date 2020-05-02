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
    public Vector2 trajectory;
    public Rigidbody2D rigidBody;
    public BoxCollider2D boxCollider;
    protected Vector2 position;
    protected Vector2 previousPosition;

    void Start()
    {

    }

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
    }

    /*
     * overloaded Static methods to return Character from most unity objects
     */
    public static Character Get(Transform obj)
    {
        return obj.GetComponent<Character>();
    }
    public static Character Get(Rigidbody2D obj)
    {
        return obj.GetComponent<Character>();
    }
    public static Character Get(BoxCollider2D obj)
    {
        return obj.GetComponent<Character>();
    }

    /*
     * Methods instantiating member variables
     */
     protected Rigidbody2D getRigidBody()
    {
        return GetComponent<Rigidbody2D>();
    }

    protected BoxCollider2D getBoxCollider()
    {
        return GetComponent<BoxCollider2D>();
    }

}
