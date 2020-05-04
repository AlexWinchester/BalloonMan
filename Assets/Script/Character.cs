using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Object
{
    public bool isHostile;
    public bool isPlayer;
   
    public float speed;
    public int currentHealth;
    public int maxHealth;
    public int currentEnergy;
    public int maxEnergy;

    public Rigidbody2D rigidBody;
    public BoxCollider2D boxCollider;

    public WeaponMelee weaponMelee;
    public WeaponRanged weaponRanged;
    public string testString = "";

    //Awake is called as soon as component is added to GameObject
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
    }

    // Called after all Update methods have completed
    protected override void LateUpdate()
    {
        base.LateUpdate();
    }

    protected override void Build()
    {
        base.Build();

        boxCollider = this.gameObject.AddComponent<BoxCollider2D>();
        rigidBody = this.gameObject.AddComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0;
        rigidBody.freezeRotation = true;
    }


    protected GameObject EquipWeaponMelee(string name, Character character, int attackSpeed, int damage, int range, Sprite sprite)
    {
        GameObject gameObject = new GameObject(name);
        weaponMelee = gameObject.AddComponent<WeaponMelee>();
        weaponMelee.Character(character)
            .AttackSpeed(attackSpeed)
            .Damage(damage)
            .Range(range)
            .Sprite(sprite);

        return gameObject;
    }

    protected GameObject EquipWeaponRanged(string name, Character character, int attackSpeed, int damage, int range, float speedProjectile, Sprite sprite, Sprite spriteProjectile)
    {
        GameObject gameObject = new GameObject(name);
        weaponRanged = gameObject.AddComponent<WeaponRanged>();
        weaponRanged.Character(character)
            .AttackSpeed(attackSpeed)
            .Damage(damage)
            .Range(range)
            .Sprite(sprite);
        weaponRanged.SpriteProjectile(spriteProjectile)
            .SpeedProjectile(speedProjectile);

        return gameObject;
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
