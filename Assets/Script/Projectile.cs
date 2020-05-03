using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float speed, damage, range, distanceTraveled;
    public int type; // different int for damage types
    public Sprite sprite;
    public Vector2 trajectory;
    public Vector2 position;
    public Rigidbody2D rigidBody;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;

    public void Construct(Sprite sprite, Vector2 trajectory, Vector2 position, float speed, float damage, float range)
    {
        this.sprite = sprite;
        this.trajectory = trajectory;
        this.transform.position = position;
        spriteRenderer.sprite = sprite;
        this.speed = speed;
        this.damage = damage;
        this.range = range;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize variables
        speed = 0;
        damage = 0;
        range = 0;
        distanceTraveled = 0;
        type = 0;

        // Add Components
        spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
        boxCollider = this.gameObject.AddComponent<BoxCollider2D>();
        (rigidBody = this.gameObject.AddComponent<Rigidbody2D>()).gravityScale = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (distanceTraveled <= range)
        {
            // Move towards trajectory
            rigidBody.MovePosition(rigidBody.position + trajectory * speed * Time.deltaTime);
        }
        else
        {
            // Range exceeded

            // Can add option for explosion, etc. here.

            // Destroy projectile
            Object.Destroy(gameObject);
        }
    }

    /*
     * Fluent Interface setters
     */

    public Projectile Sprite(Sprite sprite)
    {
        this.sprite = sprite;
        return this;
    }

    public Projectile Trajectory(Vector2 trajectory)
    {
        this.trajectory = trajectory;
        return this;
    }

    public Projectile Position(Vector2 position)
    {
        this.position = position;
        return this;
    }

    public Projectile Speed(float speed)
    {
        this.speed = speed;
        return this;
    }

    public Projectile Damage(float damage)
    {
        this.damage = damage;
        return this;
    }

    public Projectile Range(float range)
    {
        this.range = range;
        return this;
    }
}
