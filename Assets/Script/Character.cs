using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isHostile;
    public bool isPlayer;
    public bool isMoving;
    public bool isBuilt;

    public float speed;

    public int damageMelee;
    public int damageRanged;
    public int attackSpeedMelee;
    public int attackSpeedRanged;
    public int currentHealth;
    public int maxHealth;
    public int currentEnergy;
    public int maxEnergy;

    public Vector2 trajectory;
    public Vector2 moveVelocity;

    public Rigidbody2D rigidBody;

    public BoxCollider2D boxCollider;

    public SpriteRenderer spriteRenderer;

    public Sprite sprite;

    public Vector2 position;

    public string testString = "";

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

    // Build Components of character
    protected void Build()
    {
        boxCollider = this.gameObject.AddComponent<BoxCollider2D>();
        rigidBody = this.gameObject.AddComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0;
        spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;


        isBuilt = true;
    }

    /*
     * Fluent interface setters
     */

    public Character IsHostile(bool isHostile)
    {
        this.isHostile = isHostile;
        return this;
    }

    public Character IsPlayer(bool isPlayer)
    {
        this.isPlayer = isPlayer;
        return this;
    }

    public Character Speed(float speed)
    {
        this.speed = speed;
        return this;
    }

    public Character DamageMelee(int damage)
    {
        this.damageMelee = damage;
        return this;
    }

    public Character DamageRanged(int damage)
    {
        this.damageRanged = damage;
        return this;
    }

    public Character MaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        return this;
    }

    public Character MaxEnergy(int maxEnergy)
    {
        this.maxEnergy = maxEnergy;
        return this;
    }

    public Character Trajectory(Vector2 trajectory)
    {
        this.trajectory = trajectory;
        return this;
    }

    public Character Sprite(Sprite sprite)
    {
        this.sprite = sprite;
        if (spriteRenderer)
        {
            spriteRenderer.sprite = sprite;
        }
        return this;
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
}
