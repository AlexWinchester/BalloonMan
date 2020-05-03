using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int attackSpeed, damage, range;
    public Rigidbody2D rigidBody;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public Character character;

    protected int elapsedFrames;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
        boxCollider = this.gameObject.AddComponent<BoxCollider2D>();
        (rigidBody = this.gameObject.AddComponent<Rigidbody2D>()).gravityScale = 0;

        elapsedFrames = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Move weapon with character
        rigidBody.MovePosition(rigidBody.position + character.moveVelocity * Time.deltaTime);

        elapsedFrames++;
    }

    // Fluent interface
    public Weapon AttackSpeed(float attackSpeed)
    {
        this.attackSpeed = attackSpeed;
        return this;
    }

    public Weapon Damage(int damage)
    {
        this.damage = damage;
        return this;
    }

    public Weapon Range(int range)
    {
        this.range = range;
        return this;
    }

    public Weapon Sprite(Sprite sprite)
    {
        this.sprite = sprite;
        this.spriteRenderer.sprite = this.sprite;
        return this;
    }

    public Weapon Character(Character  character)
    {
        this.character = character;
        return this;
    }
}
