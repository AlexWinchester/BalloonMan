using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character {

    public Sprite spriteWeaponMelee;
    public Sprite spriteWeaponRanged;
    public Sprite spriteProjectile;

    //Awake is called as soon as component is added to GameObject
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start() {
        base.Start();

        this.isPlayer = true;
        speed = 3;
        maxHealth = 10;
        currentHealth = maxHealth;
        maxEnergy = 10;
        currentEnergy = maxEnergy;

        // Set Sprite
        this.Sprite(Resources.Load<Sprite>("Sprites/balloon_man_revised"));

        spriteWeaponMelee = Resources.Load<Sprite>("Sprites/Sword");
        spriteWeaponRanged = Resources.Load<Sprite>("Sprites/Gun");
        spriteProjectile = Resources.Load<Sprite>("Sprites/Circle");

        // Weapons (Will be grabbed by database later)

        EquipWeaponMelee(this, 50, 2, 1, spriteWeaponMelee);
        EquipWeaponRanged(this, 100, 1, 5, 2, spriteWeaponRanged, spriteProjectile);

        weaponRanged.AttackSpeed(200)
            .Damage(1)
            .Range(5)
            .Sprite(spriteWeaponRanged);
    }

    protected override void Update() {
        base.Update();
        // Check attacks
        CheckMeleeSwing();
        CheckRangedShoot();

    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
    }


    void FixedUpdate() {
        // Move Player with keyboard
        trajectory = GetTrajectory();
        moveVelocity = trajectory * speed;
        rigidBody.MovePosition(rigidBody.position + moveVelocity * Time.fixedDeltaTime);
    }


    private Vector2 GetTrajectory()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    private bool CheckMeleeSwing()
    {
        // Swing if proper frame and pressing right click
        if (Input.GetMouseButtonDown(0))
        {
            weaponMelee.Swing(
                new Vector2(
                    Input.mousePosition.x - weaponRanged.projectilePosition.x,
                    Input.mousePosition.y - weaponRanged.projectilePosition.y)
                .normalized);
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckRangedShoot()
    {
        // Shoot if proper frame and pressing right click
        if (Input.GetMouseButtonDown(1))
        {
            weaponRanged.Shoot(
                new Vector2(
                    Input.mousePosition.x - weaponRanged.projectilePosition.x,
                    Input.mousePosition.y - weaponRanged.projectilePosition.y)
                .normalized);

            return true;
        }
        else
        {
            return false;
        }
    }
}
