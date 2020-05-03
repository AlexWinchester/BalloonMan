using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isHostile;
    public bool isPlayer;
    public bool isMoving;
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
    public Rigidbody2D rigidBody;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    protected Vector2 position;
    protected Vector2 previousPosition;

    void Start()
    {
        spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
        boxCollider = this.gameObject.AddComponent<BoxCollider2D>();
        (rigidBody = this.gameObject.AddComponent<Rigidbody2D>()).gravityScale = 0;
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
        this.spriteRenderer.sprite = this.sprite;
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

    protected void Shoot(Sprite sprite, Vector2 trajectory, Vector2 position, float speed, float range, string name)
    {
        new GameObject(name).AddComponent<Projectile>()
            .Sprite(sprite)
            .Trajectory(trajectory)
            .Position(position)
            .Speed(speed)
            .Damage(damage)
            .Range(range);
    }
}
