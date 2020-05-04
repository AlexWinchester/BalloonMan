using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Object
{
    public int attackSpeed, damage, range, timer;
    public Vector2 positionOffset;
    public bool didAttack;
    public Character character;

    protected int elapsedFrames;

    //Awake is called as soon as component is added to GameObject
    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        // Initialize Variables
        timer = 0;
        didAttack = false;
        
    }

    // Update is called once per frame
    protected override void Update()
    {
    }

    protected override void FixedUpdate()
    {

        // Move weapon with character
        // rigidBody.MovePosition(rigidBody.position + character.moveVelocity * Time.deltaTime);
        transform.position = character.position + positionOffset;
    }


    protected override void LateUpdate()
    {
        base.LateUpdate();
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
        transform.position = character.position;
        return this;
    }
}
