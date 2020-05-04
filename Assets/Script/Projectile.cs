using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Object
{
    
    public float speed, damage, range, distanceTraveled;
    public int type; // different int for damage types

    public void Construct(Sprite sprite, Vector2 trajectory, Vector2 position, float speed, float damage, float range)
    {
        this.sprite = sprite;
        this.trajectory = trajectory.normalized;
        this.transform.position = position;
        spriteRenderer.sprite = sprite;
        this.speed = speed;
        this.damage = damage;
        this.range = range;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // Initialize variables
        speed = 0;
        damage = 0;
        range = 0;
        distanceTraveled = 0;
        type = 0;


    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (distanceTraveled <= range)
        {
            // Move towards trajectory
            transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3)trajectory * speed * Time.fixedDeltaTime , speed * Time.fixedDeltaTime);
            //rigidBody.MovePosition(rigidBody.position + trajectory * speed * Time.fixedDeltaTime);
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
        this.trajectory = trajectory.normalized;
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
