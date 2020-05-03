using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int attackSpeed, damage, range, timer;
    public bool didAttack;
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

        timer = 0;
        didAttack = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move weapon with character
        rigidBody.MovePosition(rigidBody.position + character.moveVelocity * Time.deltaTime);
    }


    private void LateUpdate()
    {
        // Increment timer if character did not attack
        if (!didAttack && timer < attackSpeed)
        {
            timer++;
        }
        else if (didAttack)
        {
            // Reset timer as character attacked
            timer = 0;
        }
        else
        {
            // Timer has completed but character has not attacked
        }

        // Reset didAttack
        didAttack = false;
    }

    // Fluent interface
    public Weapon AttackSpeed(int attackSpeed)
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
