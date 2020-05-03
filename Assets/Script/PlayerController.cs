using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character {

    public WeaponMelee weaponMelee;
    public WeaponRanged weaponRanged;
    public Sprite spriteWeaponMelee;
    public Sprite spriteWeaponRanged;

    private int swingTimerMelee;
    private int swingTimerRanged;
    private bool didSwing;
    private bool didShoot;

    void Start() {
        // Build Components
        Build();

        isPlayer = true;
        speed = 3;
        attackSpeedMelee = 50;
        attackSpeedRanged = 100;
        maxHealth = 10;
        currentHealth = maxHealth;
        maxEnergy = 10;
        currentEnergy = maxEnergy;
        swingTimerRanged = 0;

        // Set Sprite
        this.Sprite(Resources.Load<Sprite>("Sprites/balloon_man_revised"));

        // Weapons
        weaponMelee.AttackSpeed(100)
            .Damage(2)
            .Range(1)
            .Sprite(spriteWeaponMelee);

        weaponRanged.AttackSpeed(200)
            .Damage(1)
            .Range(5)
            .Sprite(spriteWeaponRanged);
    }

    void Update() {

        // Check attacks
        CheckMeleeSwing();
        CheckRangedShoot();

        // Move Player with keyboard
        trajectory = GetTrajectory();
        moveVelocity = trajectory * speed;
        rigidBody.MovePosition(rigidBody.position + moveVelocity * Time.deltaTime);

    }

    void LateUpdate()
    {
        
    }


    void FixedUpdate() {

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
